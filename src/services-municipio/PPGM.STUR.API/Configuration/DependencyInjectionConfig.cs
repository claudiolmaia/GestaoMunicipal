using Microsoft.Extensions.DependencyInjection;
using PPGM.STUR.API.Data.Repository;
using PPGM.STUR.API.Models;

namespace PPGM.STUR.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IIptuRepository, IptuRepository>();            
        }
    }
}
