using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        List<FuncionarioDomain> ListarUnico(int IdUnico);

        List<FuncionarioDomain> ListarPesquisa(string Buscar);

        void Adicionar(FuncionarioDomain funcionarioRecebido);

        void Atualizar(FuncionarioDomain funcionarioAtualizar, int IdAtualizar);

        void Deletar(int IdDelete);
    }
}
