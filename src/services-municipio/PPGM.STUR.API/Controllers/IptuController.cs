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

        [HttpGet("iptu/{cpf}")]
        public async Task<List<Iptu>> ObterPorCpf(string cpf)
        {
            return await _iptuRepository.ObterPorCpf(cpf);
        }
    }
}

