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

        public async Task<Iptu> ObterPorId(int ID)
        {
            var result = await _context.iptu.Where(x => x.Id == ID).FirstAsync();
            return result;
        }

        public async Task<List<Iptu>> ObterPorCpf(string cpf)
        {
            var result = await _context.iptu.Where(x => x.CPF == cpf).ToListAsync();
            return result;
        }

        public async Task<List<Iptu>> ObterTodosAbertos()
        {
            var result = await _context.iptu.Where(x => !x.IsPago).ToListAsync();
            return result;
        }

        public async Task<bool> BaixarIptu(int id)
        {
            var iptu = await _context.iptu.FindAsync(id);
            if(iptu != null)
            {
                iptu.IsPago = true;
                _context.iptu.Update(iptu);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }    
}
