using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PPGM.BFF.Integracao.Services;
using PPGM.BFF.Integracao.Extensions;

namespace PPGM.BFF.Integracao.Services
{
    public interface IUsuarioService
    {

    }

    public class UsuarioService : Service, IUsuarioService
    {
        private readonly HttpClient _httpClient;
        public UsuarioService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.UsuarioUrl);
        }
    }
}
