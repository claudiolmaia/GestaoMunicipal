using Microsoft.AspNetCore.Mvc;
using PPGM.SAEM.API.Models;
using PPGM.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.SAEM.API.Controllers
{
    public class ConsultaController : MainController
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        [HttpGet("consulta")]
        public async Task<List<Consulta>> ObterPorCpf(string cpf)
        {
            return await _consultaRepository.ObterPorCpf(cpf);
        }
    }
}
