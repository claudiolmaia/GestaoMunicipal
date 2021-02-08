using Microsoft.Extensions.DependencyInjection;
using PPGM.SAEM.API.Data;
using PPGM.SAEM.API.Models;

namespace PPGM.SAEM.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IConsultaRepository, ConsultaRepository>();            
        }
    }
}
