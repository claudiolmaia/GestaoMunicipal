using Microsoft.AspNetCore.Mvc;
using PPGM.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.SAFIM.API.Controllers
{
    public class FinanceiroController : MainController
    {
        
        [HttpGet("financeiro")]
        public async Task<List<string>> ObterDados()
        {
            throw new NotImplementedException();
        }

    }
}
