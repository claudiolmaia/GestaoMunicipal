using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPGM.Usuarios.API.Services;
using PPGM.Core.Utils;
using PPGM.MessageBus;

namespace PPGM.Usuarios.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroUsuarioIntegrationHandler>();
        }
    }
}