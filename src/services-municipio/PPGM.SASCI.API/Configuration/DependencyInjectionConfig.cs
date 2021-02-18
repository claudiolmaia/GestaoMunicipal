using Microsoft.Extensions.DependencyInjection;
using PPGM.SASCI.API.Models;
using PPGM.SASCI.API.Data.Repository;

namespace PPGM.SASCI.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IConsultaRepository, ConsultaRepository>();            
        }
    }
}
