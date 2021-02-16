using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PPGM.BFF.Integracao.Services;
using PPGM.WebAPI.Core.Controllers;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Controllers
{
    
    public class IptuController : MainController
    {
        private readonly IDistributedCache _cache;
        private readonly ISturService _sturService;
        private readonly IUsuarioService _usuarioService;
        public IptuController(IDistributedCache cache,
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
            var cacheName = $"IptuUsuario{userId}";
            string jsonCache = await _cache.GetStringAsync(cacheName);
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
                DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                _cache.SetString(cacheName, jsonCache, opcoesCache);

                //return CustomResponse(await _sturService.ObterIptuPorCpf(cpf));
            }

            return CustomResponse(jsonCache);
        }

    }
}
