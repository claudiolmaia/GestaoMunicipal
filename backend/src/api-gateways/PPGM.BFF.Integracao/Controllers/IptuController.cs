using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPGM.BFF.Integracao.Services;
using PPGM.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Controllers
{
    [Authorize]
    public class IptuController : MainController
    {
        private readonly ISturService _sturService;
        public IptuController(ISturService sturService)
        {
            _sturService = sturService;
        }

        [HttpGet("integracao/iptu/{cpf}")]        
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            return CustomResponse(await _sturService.ObterIptuPorCpf(cpf));
        }

    }
}
