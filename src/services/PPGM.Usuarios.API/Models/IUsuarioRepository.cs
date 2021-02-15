using PPGM.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.Usuarios.API.Models
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void Adicionar(Usuario usuario);
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<Usuario> ObterPorCpf(string cpf);

        Task<Usuario> ObterUsuarioById(Guid userId);
    }
}
