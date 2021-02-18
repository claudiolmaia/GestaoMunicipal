using Microsoft.EntityFrameworkCore;
using PPGM.SASCI.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPGM.SASCI.API.Data.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly SasciContext _context;
        public ConsultaRepository(SasciContext context)
        {
            _context = context;
        }
        public async Task<List<Consulta>> ObterPorCpf(string cpf)
        {
            var result = await _context.consulta.Where(x => x.CPF == cpf).ToListAsync();
            return result;
        }
    }
}
