using Microsoft.EntityFrameworkCore;
using PPGM.STUR.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PPGM.STUR.API.Data.Repository
{
    public class IptuRepository : IIptuRepository
    {
        private readonly SturContext _context;
        public IptuRepository(SturContext context)
        {
            _context = context;
        }
        
        public async Task<List<Iptu>> ObterPorCpf(string cpf)
        {
            var result = await _context.iptu.Where(x => x.CPF == cpf).ToListAsync();
            return result;
        }
    }    
}
