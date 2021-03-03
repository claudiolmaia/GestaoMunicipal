using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.SASCI.API.Models
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ObterPorCpf(string cpf);
        Task<List<Consulta>> ObterTodas();
        Task<bool> RemoverConsulta(int id);
        Task<Consulta> AdicionarConsulta(Consulta data);

    }
}
