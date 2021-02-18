using Microsoft.AspNetCore.Mvc;
using PPGM.SASCI.API.Models;
using PPGM.WebAPI.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.SASCI.API.Controllers
{
    public class ConsultaController : MainController
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        [HttpGet("consulta/{cpf}")]
        public async Task<List<Consulta>> ObterPorCpf(string cpf)
        {
            return await _consultaRepository.ObterPorCpf(cpf);
        }
    }
}
