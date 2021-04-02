using Microsoft.AspNetCore.Mvc;
using PPGM.STUR.API.Models;
using PPGM.WebAPI.Core.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.STUR.API.Controllers
{
    public class IptuController : MainController
    {
        private readonly IIptuRepository _iptuRepository;

        public IptuController(IIptuRepository iptuRepository)
        {
            _iptuRepository = iptuRepository;
        }

        [HttpGet("iptu")]
        public async Task<List<Iptu>> ObterTodos()
        {
            return await _iptuRepository.ObterTodosAbertos();
        }

        [HttpGet("iptu/cpf/{cpf}")]
        public async Task<List<Iptu>> ObterPorCpf(string cpf)
        {
            return await _iptuRepository.ObterPorCpf(cpf);
        }

        [HttpGet("iptu/{id}")]
        public async Task<Iptu> ObterPorID(int id)
        {
            return await _iptuRepository.ObterPorId(id);
        }

        [HttpPut("iptu/{id}")]
        public async Task<bool> Baixar(int id)
        {
            return await _iptuRepository.BaixarIptu(id);
        }
    }
}

