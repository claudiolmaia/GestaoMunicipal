using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PPGM.BFF.Integracao.Extensions;
using PPGM.BFF.Integracao.Models;

namespace PPGM.BFF.Integracao.Services
{
    public interface ISasciService
    {
        Task<List<ConsultaDTO>> ObterConsultaPorCpf(string cpf);
    }

    public class SasciService: Service, ISasciService
    {
        private readonly HttpClient _httpClient;
        public SasciService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.SasciUrl);
        }

        public async Task<List<ConsultaDTO>> ObterConsultaPorCpf(string cpf)
        {
            var response = await _httpClient.GetAsync($"/consulta/{cpf}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<List<ConsultaDTO>>(response);
        }
    }
}
