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
    public class AlunoController : MainController
    {
        private readonly ISaemService _saemService;

        public AlunoController(ISaemService saemService)
        {
            _saemService = saemService;
        }

        [HttpGet("integracao/aluno")]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _saemService.ObterTodosAlunos());
        }

        [HttpGet("integracao/aluno/{cpf}")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            return CustomResponse(await _saemService.ObterAlunoPorCpf(cpf));
        }
    }
}
