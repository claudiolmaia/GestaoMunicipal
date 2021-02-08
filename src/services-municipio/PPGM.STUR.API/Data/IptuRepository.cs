using PPGM.STUR.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PPGM.STUR.API.Data
{
    public class IptuRepository : IIptuRepository
    {
        private readonly string _dados = "[{\"Id\":1,\"Logradouro\":\"Rua Pedro Aguia\",\"Numero\":20,\"Cep\":\"37220000\",\"Bairro\":\"Centro\",\"UF\":\"MG\",\"Valor\":550,\"IsPago\":false},{\"Id\":2,\"Logradouro\":\"Rua Santos Dumont\",\"Numero\":50,\"Cep\":\"37220000\",\"Bairro\":\"Centro\",\"UF\":\"MG\",\"Valor\":650,\"IsPago\":true},{\"Id\":3,\"Logradouro\":\"Rua Omar Soares\",\"Numero\":20,\"Cep\":\"37220000\",\"Bairro\":\"Centro\",\"UF\":\"MG\",\"Valor\":150,\"IsPago\":false},{\"Id\":4,\"Logradouro\":\"Rua José Mourão\",\"Numero\":229,\"Cep\":\"37220000\",\"Bairro\":\"Centro\",\"UF\":\"MG\",\"Valor\":900,\"IsPago\":false},{\"Id\":5,\"Logradouro\":\"Rua Oito de Setembro\",\"Numero\":70,\"Cep\":\"37220000\",\"Bairro\":\"Centro\",\"UF\":\"MG\",\"Valor\":720,\"IsPago\":true},{\"Id\":6,\"Logradouro\":\"Rua Dona Francelina\",\"Numero\":123,\"Cep\":\"37220000\",\"Bairro\":\"Centro\",\"UF\":\"MG\",\"Valor\":440,\"IsPago\":false}]";

        public Task<List<Iptu>> ObterPorCpf(string cpf)
        {
            int rnd = new Random().Next(1, 5);

            var resultado = JsonSerializer.Deserialize<List<Iptu>>(_dados).Take(rnd);
            return Task.Run(() => resultado.ToList());
        }
    }    
}
