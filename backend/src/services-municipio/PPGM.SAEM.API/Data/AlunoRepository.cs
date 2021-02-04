using PPGM.SAEM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PPGM.SAEM.API.Data
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _data = "{\"Id\":1,\"Nome\":\"Claudio Lucio Maia\",\"Cpf\":\"00489949100\",\"DataNascimento\":\"1985-11-04\",\"Sexo\":\"M\"},{\"Id\":2,\"Nome\":\"Machado de Assis\",\"Cpf\":\"41732631042\",\"DataNascimento\":\"1890-01-01\",\"Sexo\":\"F\"},{\"Id\":3,\"Nome\":\"Tarsila do Amaral\",\"Cpf\":\"11791965032\",\"DataNascimento\":\"2000-05-01\",\"Sexo\":\"F\"},{\"Id\":4,\"Nome\":\"Maria Aparecida\",\"Cpf\":\"33623767034\",\"DataNascimento\":\"1990-06-06\",\"Sexo\":\"F\"},{\"Id\":5,\"Nome\":\"John Doe\",\"Cpf\":\"96727632049\",\"DataNascimento\":\"1980-05-04\",\"Sexo\":\"M\"}";
        public Task<List<Aluno>> ObterTodos()
        {
            var alunos = JsonSerializer.Deserialize<List<Aluno>>(_data);
            return Task.Run(() => alunos);

        }

        public Task<Aluno> ObterPorId(int id)
        {
            var aluno = JsonSerializer.Deserialize<List<Aluno>>(_data).Find(x => x.Id == id);
            return Task.Run(() => aluno);
        }

        public Task<Aluno> ObterPorCpf(string cpf)
        {
            var aluno = JsonSerializer.Deserialize<List<Aluno>>(_data).Find(x => x.Cpf == cpf);
            return Task.Run(() => aluno);
        }
    }
}
