using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PPGM.BFF.Integracao.Extensions;
using PPGM.BFF.Integracao.Models;

namespace PPGM.BFF.Integracao.Services
{
    public interface ISturService
    {
        Task<IptuDTO> ObterIptuPorCpf(string cpf);
    }

    public class SturService : Service, ISturService
    {
        private readonly HttpClient _httpClient;

        public SturService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.SturUrl);
        }

        public async Task<IptuDTO> ObterIptuPorCpf(string cpf)
        {
            var response = await _httpClient.GetAsync($"/iptu/{cpf}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IptuDTO>(response);
        }
    }
}
