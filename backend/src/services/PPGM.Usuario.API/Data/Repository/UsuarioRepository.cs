using Microsoft.EntityFrameworkCore;
using PPGM.Usuarios.API.Data;
using PPGM.Core.Data;
using PPGM.Usuarios.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPGM.Usuarios.API.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext _context;

        public UsuarioRepository(UsuariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public Task<Usuario> ObterPorCpf(string cpf)
        {
            return _context.Usuarios.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
