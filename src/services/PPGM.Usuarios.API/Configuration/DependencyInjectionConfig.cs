using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PPGM.Usuarios.API.Application.Commands;
using PPGM.Usuarios.API.Application.Events;
using PPGM.Usuarios.API.Data;
using PPGM.Usuarios.API.Data.Repository;
using PPGM.Usuarios.API.Models;
using PPGM.Core.Mediator;
using PPGM.WebAPI.Core.Usuario;

namespace PPGM.Usuarios.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<INotificationHandler<UsuarioRegistradoEvent>, UsuarioEventHandler>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<UsuariosContext>();
        }
    }
}