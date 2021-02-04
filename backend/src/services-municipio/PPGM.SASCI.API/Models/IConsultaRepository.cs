using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.SAEM.API.Models
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ObterPorCpf(string cpf);
    }
}
