using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.STUR.API.Models
{
    public interface IIptuRepository
    {
        Task<List<Iptu>> ObterTodosAbertos();
        Task<List<Iptu>> ObterPorCpf(string cpf);
        Task<bool> BaixarIptu(int id);
    }
}
