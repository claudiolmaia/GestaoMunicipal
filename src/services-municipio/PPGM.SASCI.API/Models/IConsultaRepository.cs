using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.SASCI.API.Models
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ObterPorCpf(string cpf);
    }
}
