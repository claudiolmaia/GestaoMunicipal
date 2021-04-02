using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPGM.BFF.Integracao.Services;
using PPGM.WebAPI.Core.Controllers;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Controllers
{
    [Authorize]
    public class IptuController : MainController
    {
        private readonly ICacheService _cache;
        private readonly ISturService _sturService;
        private readonly IUsuarioService _usuarioService;
        private readonly string _cacheName = "iptu";

        public IptuController(ICacheService cache,
            ISturService sturService,
            IUsuarioService usuarioService)
        {
            _cache = cache;
            _sturService = sturService;
            _usuarioService = usuarioService;
        }

        [HttpGet("integracao/iptu/{userId}")]
        public async Task<IActionResult> ObterPorCpf(Guid userId)
        {
            var cacheName = $"{_cache}-{userId}";
            string jsonCache = await _cache.GetCache(cacheName);
            if (string.IsNullOrEmpty(jsonCache))
            {
                var cpf = await _usuarioService.ObterCpfUsuario(userId);
                var data = await _sturService.ObterIptuPorCpf(cpf);
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
        [HttpGet("integracao/iptu")]
        public async Task<IActionResult> ObterTodos()
        {
            string jsonCache = await _cache.GetCache(_cacheName);
            if (string.IsNullOrEmpty(jsonCache))
            {
                var data = await _sturService.ObterTodos();
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
        [HttpPut("integracao/iptu/{id}")]
        public async Task<IActionResult> Baixar(int id)
        {
            var result = await _sturService.Baixar(id);
            _cache.RemoveCache(_cacheName);

            return CustomResponse(result);
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpGet("integracao/iptu/pdf/{id}")]
        public async Task<IActionResult> IptuPDF(int id)
        {
            var result = await _sturService.GerarPDF(id);
            _cache.RemoveCache(_cacheName);

            return CustomResponse(result);
        }
    }
}