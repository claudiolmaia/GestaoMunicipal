using Microsoft.Extensions.DependencyInjection;
using PPGM.SASCI.API.Data;
using PPGM.SASCI.API.Models;

namespace PPGM.SASCI.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();            
        }
    }
}
