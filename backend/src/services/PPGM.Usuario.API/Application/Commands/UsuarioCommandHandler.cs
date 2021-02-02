using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PPGM.Usuarios.API.Application.Events;
using PPGM.Usuarios.API.Models;
using PPGM.Core.Messages;

namespace PPGM.Usuarios.API.Application.Commands
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<RegistrarUsuarioCommand, ValidationResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var usuario = new Usuario(message.Id, message.Nome, message.Email, message.Cpf);

            var usuarioExistente = await _usuarioRepository.ObterPorCpf(usuario.Cpf.Numero);

            if (usuarioExistente != null)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            _usuarioRepository.Adicionar(usuario);

            usuario.AdicionarEvento(new UsuarioRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            return await PersistirDados(_usuarioRepository.UnitOfWork);
        }
    }
}
