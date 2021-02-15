using Microsoft.AspNetCore.Mvc;
using PPGM.Core.Mediator;
using PPGM.Usuarios.API.Models;
using PPGM.WebAPI.Core.Controllers;
using PPGM.WebAPI.Core.Usuario;
using System;
using System.Threading.Tasks;

namespace PPGM.Usuarios.API.Controllers
{
    public class UsuariosController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("usuario")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            var usuario = await _usuarioRepository.ObterPorCpf(cpf);

            return usuario == null ? NotFound() : CustomResponse(usuario);
        }


        [HttpGet("usuario/ObterCpf/{userId}")]
        public async Task<IActionResult> ObterCpfById(Guid userId)
        {
            var usuario = await _usuarioRepository.ObterUsuarioById(userId);

            return usuario == null ? NotFound() : CustomResponse(usuario.Cpf.Numero);
        }

    }
}
