using Microsoft.AspNetCore.Mvc;
using PPGM.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.SAFIM.API.Controllers
{
    public class AdministrativoController : MainController
    {
        [HttpGet("administrativo")]
        public async Task<List<string>> ObterDados()
        {
            throw new NotImplementedException();
        }
    }
}
