using Microsoft.AspNetCore.Mvc;
using PPGM.BFF.Integracao.Services;
using PPGM.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Controllers
{
    public class AlunoController : MainController
    {
        private readonly ISaemService _saemService;

        public AlunoController(ISaemService saemService)
        {
            _saemService = saemService;
        }

        [HttpGet]
        [Route("integracao/aluno")]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _saemService.ObterTodosAlunos());
        }

        [HttpGet]
        [Route("integracao/aluno/{cpf}")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            return CustomResponse(await _saemService.ObterAlunoPorCpf(cpf));
        }
    }
}
