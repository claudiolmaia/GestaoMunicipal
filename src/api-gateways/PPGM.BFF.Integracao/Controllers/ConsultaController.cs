using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPGM.BFF.Integracao.Models;
using PPGM.BFF.Integracao.Services;
using PPGM.WebAPI.Core.Controllers;


namespace PPGM.BFF.Integracao.Controllers
{
    [Authorize]
    public class ConsultaController : MainController
    {
        private readonly ISasciService _sasciService;

        public ConsultaController(ISasciService sasciService)
        {
            _sasciService = sasciService;
        }

        [HttpGet("integracao/consulta/{cpf}")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            return CustomResponse(await _sasciService.ObterConsultaPorCpf(cpf));
        }

    }
}
