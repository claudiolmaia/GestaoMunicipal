using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPGM.BFF.Integracao.Models;
using PPGM.BFF.Integracao.Services;
using PPGM.Core.Communication;
using PPGM.WebAPI.Core.Controllers;


namespace PPGM.BFF.Integracao.Controllers
{
    [Authorize]
    public class ConsultaController : MainController
    {
        private readonly ISasciService _sasciService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICacheService _cache;
        private readonly string _cacheName = "consulta";

        public ConsultaController(ISasciService sasciService,
            IUsuarioService usuarioService,
            ICacheService cache)
        {
            _sasciService = sasciService;
            _usuarioService = usuarioService;
            _cache = cache;
        }

        [HttpGet("integracao/consulta/{userId}")]
        public async Task<IActionResult> ObterConsultaUsuario(Guid userId)
        {
            var cacheName = $"{_cacheName}-{userId}";
            string jsonCache = await _cache.GetCache(cacheName);
            if (string.IsNullOrEmpty(jsonCache))
            {
                var cpf = await _usuarioService.ObterCpfUsuario(userId);
                var data = await _sasciService.ObterConsultaPorCpf(cpf);

                var jsOption = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                jsonCache = JsonSerializer.Serialize(data, jsOption);

                _cache.CreateCache(cacheName, jsonCache, 5);
            }

            return CustomResponse(jsonCache);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("integracao/consulta")]
        public async Task<IActionResult> ObterConsulta()
        {
            string jsonCache = await _cache.GetCache(_cacheName);
            if (string.IsNullOrEmpty(jsonCache))
            {
                var data = await _sasciService.ObterConsultas();

                var jsOption = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                jsonCache = JsonSerializer.Serialize(data, jsOption);

                _cache.CreateCache(_cacheName, jsonCache, 5);
            }

            return CustomResponse(jsonCache);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("integracao/consulta")]
        public async Task<IActionResult> Adicionar(ConsultaDTO consulta)
        {
            var verifica = await _sasciService.ExisteConsulta(consulta);
            if(!verifica)
            {
                var result = await _sasciService.AdicionarConsulta(consulta);
                _cache.RemoveCache(_cacheName);
                return CustomResponse(result);
            }

            ResponseResult error = new ResponseResult();
            error.Errors.Mensagens.Add("Horário já possui atendimento");
            return CustomResponse(error);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("integracao/consulta/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            _cache.RemoveCache(_cacheName);
            var result = await _sasciService.RemoverConsulta(id);
            return CustomResponse(result);
        }

    }
}
