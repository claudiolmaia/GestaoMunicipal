using PPGM.SAEM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PPGM.SAEM.API.Data
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly string _consultas = "[{\"Id\":1,\"DataConsulta\":\"2021-03-01\",\"Medico\":\"John Doe\",\"Unidade\":\"PSF Unidade Centro\"},{\"Id\":2,\"DataConsulta\":\"2021-03-01\",\"Medico\":\"John Doe\",\"Unidade\":\"PSF Chácara da Rosas\"},{\"Id\":3,\"DataConsulta\":\"2021-03-01\",\"Medico\":\"John Doe\",\"Paciente\":\"Cláudio Lúcio Maia\",\"CpfPaciente\":\"00489949100\",\"Unidade\":\"PSF Unidade Centro\"},{\"Id\":4,\"DataConsulta\":\"2021-03-01\",\"Medico\":\"John Doe\",\"Paciente\":\"Cláudio Lúcio Maia\",\"CpfPaciente\":\"00489949100\",\"Unidade\":\"PSF Faquines \"},{\"Id\":5,\"DataConsulta\":\"2021-03-01\",\"Medico\":\"John Doe\",\"Paciente\":\"Cláudio Lúcio Maia\",\"CpfPaciente\":\"00489949100\",\"Unidade\":\"PSF Unidade Centro\"}]";
        public Task<List<Consulta>> ObterPorCpf(string cpf)
        {
            int rnd = new Random().Next(1, 5);
            var resultado = JsonSerializer.Deserialize<List<Consulta>>(_consultas).Take(rnd);
            return Task.Run(() => resultado.ToList());
        }
    }
}
