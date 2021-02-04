using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.SAEM.API.Models
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> ObterTodos();
        Task<Aluno> ObterPorId(int id);
        Task<Aluno> ObterPorCpf(string cpf);
    }
}
