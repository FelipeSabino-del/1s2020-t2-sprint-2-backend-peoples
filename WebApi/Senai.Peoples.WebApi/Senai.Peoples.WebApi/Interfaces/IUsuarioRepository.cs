using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain BuscarPorId(int id);

        void Cadastrar (UsuarioDomain UsuarioCadastrado);

        void Atualizar(int id, UsuarioDomain UsuarioAtualizado);

        void Deletar(int id);
    }
}
