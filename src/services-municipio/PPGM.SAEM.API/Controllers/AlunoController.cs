using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPGM.SASCI.API.Models;
using PPGM.WebAPI.Core.Controllers;

namespace PPGM.SASCI.API.Controllers
{
    public class AlunoController : MainController
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)    
        {
            _alunoRepository = alunoRepository;
        }
        
        [HttpGet("aluno")]
        public async Task<List<Aluno>> ObterTodos()
        {
            return await _alunoRepository.ObterTodos();
        }

        [HttpGet("aluno/{id}")]
        public async Task<Aluno> ObterPorId(int id)
        {
            return await _alunoRepository.ObterPorId(id);
        }

        [HttpGet("aluno/{cpf}")]
        public async Task<Aluno> ObterPorCpf(string cpf)
        {
            return await _alunoRepository.ObterPorCpf(cpf);
        }


    }
}
