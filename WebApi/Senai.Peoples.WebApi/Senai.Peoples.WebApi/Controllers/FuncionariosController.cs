using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpGet("{IdUnico}")]
        public IEnumerable<FuncionarioDomain> GetUnico(int IdUnico)
        {
            return _funcionarioRepository.ListarUnico(IdUnico);
        }   

        [HttpGet("Buscar/{Buscar}")]
        public IEnumerable<FuncionarioDomain> GetPesquisa(string Buscar)
        {
            return _funcionarioRepository.ListarPesquisa(Buscar);
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain funcionarioRecebido)
        {
            if (funcionarioRecebido != null)
            {
                if (funcionarioRecebido.Nome == null)
                {
                    return BadRequest("Nome do funcionário obrigatório");
                }
                _funcionarioRepository.Adicionar(funcionarioRecebido);
                return StatusCode(201);
                }
                return StatusCode(400);
        }

        [HttpPut("{IdAtualizar}")]
        public IActionResult Put(FuncionarioDomain funcionarioAtualizar, int IdAtualizar)
        {
            if (funcionarioAtualizar != null)
            {
                _funcionarioRepository.Atualizar(funcionarioAtualizar, IdAtualizar);
                return StatusCode(200);
            }
            return StatusCode(400);
        }

        [HttpDelete("{IdDelete}")]
        public IActionResult Delete(int IdDelete)
        {
            _funcionarioRepository.Deletar(IdDelete);
            return StatusCode(200);
        }
    }
}