using Microsoft.EntityFrameworkCore;
using PPGM.SASCI.API.Models;
using System;
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

        public async Task<List<Consulta>> ObterTodas()
        {
            DateTime dt_minima = DateTime.Now.AddHours(0).AddMinutes(0).AddSeconds(0);
            var result = await _context.consulta.Where(x => x.DataConsulta >= dt_minima).ToListAsync();
            return result;
        }

        public async Task<bool> RemoverConsulta(int id)
        {
            var consulta = await _context.consulta.FindAsync(id);
            if (consulta != null)
            {
                var result = _context.consulta.Remove(consulta);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ValidaExisteConsulta(Consulta data)
        {
            var dt_tempoConsulta = data.DataConsulta.AddMinutes(30);
            var verifica = await _context.consulta.AnyAsync(x => x.Unidade == data.Unidade && x.Consultorio == data.Consultorio && x.DataConsulta >= data.DataConsulta && data.DataConsulta <= dt_tempoConsulta);
            if (verifica)
                return true;
            
            return false;
        }

        public async Task<Consulta> AdicionarConsulta(Consulta data)
        {
            var dt_tempoConsulta = data.DataConsulta.AddMinutes(30);
            var verifica = await _context.consulta.AnyAsync(x => x.Unidade == data.Unidade && x.Consultorio == data.Consultorio && x.DataConsulta >= data.DataConsulta && data.DataConsulta <= dt_tempoConsulta);
            if (verifica)
                throw new ArgumentException("Horário já possui consulta");

            var result = await _context.consulta.AddAsync(data);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
