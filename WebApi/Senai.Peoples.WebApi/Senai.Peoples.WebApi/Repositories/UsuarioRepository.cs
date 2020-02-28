using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public void Cadastrar(UsuarioDomain UsuarioCadastrado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(Email, Senha, IdTipoUsuario) " +
                                     "VALUES (@Email, @Senha, 2)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", UsuarioCadastrado.Email);
                    cmd.Parameters.AddWithValue("@Sobrenome", UsuarioCadastrado.Senha);

                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> tipos = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdUsuario, Email, TipoUsuario.Titulo FROM Usuario INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain();
                        usuario.IdUsuario = Convert.ToInt32(rdr[0]);
                        usuario.Email = rdr["Email"].ToString();
                        usuario.Senha = rdr["Senha"].ToString();
                        usuario.IdUsuario = Convert.ToInt32(rdr[3]);
                        tipos.Add(usuario);
                    }
                    return tipos;
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdUsuario, Email, TipoUsuario.Titulo FROM Usuario INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario WHERE IdTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain();
                        usuario.IdUsuario = Convert.ToInt32(rdr[0]);
                        usuario.Email = rdr["Email"].ToString();
                        usuario.Senha = rdr["Senha"].ToString();
                        usuario.IdUsuario = Convert.ToInt32(rdr[3]);
                        return usuario;
                    }
                    return null;
                }
            }
        }

        public void Atualizar(int id, UsuarioDomain UsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "UPDATE Usuario SET IdTipoUsuario = @Tipo WHERE IdTipoUsuario = @ID;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", UsuarioAtualizado.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                }
            }
        }


        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "DELETE Usuario WHERE IdUsuario = @ID;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

    }
}
