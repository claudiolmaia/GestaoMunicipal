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

        [HttpGet("consulta")]
        public async Task<List<Consulta>> ObterTodas()
        {
            return await _consultaRepository.ObterTodas();
        }

        [HttpGet("consulta/{cpf}")]
        public async Task<List<Consulta>> ObterPorCpf(string cpf)
        {
            return await _consultaRepository.ObterPorCpf(cpf);
        }

        [HttpPost("consulta")]
        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            return await _consultaRepository.AdicionarConsulta(consulta);
        }

        [HttpDelete("consulta/{id}")]
        public async Task<bool> Remover(int id)
        {
            return await _consultaRepository.RemoverConsulta(id);
        }

        [HttpGet("consulta/valida")]
        public async Task<bool> ExisteConsulta([FromQuery]Consulta consulta)
        {
            return await _consultaRepository.ValidaExisteConsulta(consulta);
        }
    }
}
