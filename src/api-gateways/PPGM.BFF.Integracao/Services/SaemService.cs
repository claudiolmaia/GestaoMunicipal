using Microsoft.Extensions.Options;
using PPGM.BFF.Integracao.Extensions;
using PPGM.BFF.Integracao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Services
{
    public interface ISaemService
    {
        Task<AlunoDTO> ObterAlunoPorCpf(string cpf);
        Task<AlunoDTO> ObterAlunoPorId(int id);
        Task<List<AlunoDTO>> ObterTodosAlunos();
    }
    public class SaemService : Service, ISaemService
    {
        private readonly HttpClient _httpClient;

        public SaemService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.SaemUrl);
        }

        public async Task<AlunoDTO> ObterAlunoPorCpf(string cpf)
        {
            var response = await _httpClient.GetAsync($"/aluno/{cpf}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<AlunoDTO>(response);
        }

        public async Task<AlunoDTO> ObterAlunoPorId(int id)
        {
            var response = await _httpClient.GetAsync($"/aluno/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<AlunoDTO>(response);
        }

        public async Task<List<AlunoDTO>> ObterTodosAlunos()
        {
            var response = await _httpClient.GetAsync($"/aluno");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<List<AlunoDTO>>(response);
        }

    }
}
