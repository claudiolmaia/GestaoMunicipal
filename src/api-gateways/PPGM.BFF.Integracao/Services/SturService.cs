using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PPGM.BFF.Integracao.Extensions;
using PPGM.BFF.Integracao.Models;

namespace PPGM.BFF.Integracao.Services
{
    public interface ISturService
    {
        Task<List<IptuDTO>> ObterIptuPorCpf(string cpf);
        Task<List<IptuDTO>> ObterTodos();
        Task<bool> Baixar(int id);
    }

    public class SturService : Service, ISturService
    {
        private readonly HttpClient _httpClient;

        public SturService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.SturUrl);
        }

        public async Task<List<IptuDTO>> ObterIptuPorCpf(string cpf)
        {
            var response = await _httpClient.GetAsync($"/iptu/{cpf}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<List<IptuDTO>>(response);
        }

        public async Task<List<IptuDTO>> ObterTodos()
        {
            var response = await _httpClient.GetAsync($"/iptu");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<List<IptuDTO>>(response);
        }

        public async Task<bool> Baixar(int id)
        {
            var content = ObterConteudo("");
            var response = await _httpClient.PutAsync($"/iptu/{id}", content);

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<bool>(response);
        }
    }
}
