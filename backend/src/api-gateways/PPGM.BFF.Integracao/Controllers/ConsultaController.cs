using Microsoft.AspNetCore.Mvc;
using PPGM.BFF.Integracao.Services;
using PPGM.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Controllers
{
    public class ConsultaController : MainController
    {
        private readonly ISasciService _sasciService;

        public ConsultaController(ISasciService sasciService)
        {
            _sasciService = sasciService;
        }

        [HttpGet]
        [Route("integracao/aluno/{cpf}")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            return CustomResponse(await _sasciService.ObterConsultaPorCpf(cpf));
        }

    }
}
