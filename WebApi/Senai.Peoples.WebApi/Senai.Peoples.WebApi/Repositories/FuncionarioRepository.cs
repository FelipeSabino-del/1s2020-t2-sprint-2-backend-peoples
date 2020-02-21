using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132;";

        public void Adicionar(FuncionarioDomain funcionarioRecebido)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @DtNascimento)";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioRecebido.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioRecebido.Sobrenome);
                    cmd.Parameters.AddWithValue("@DtNascimento", funcionarioRecebido.DataNascimento);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionarioAtualizar, int IdAtualizar)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DtNascimento WHERE IdFuncionario = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", IdAtualizar);
                    cmd.Parameters.AddWithValue("@Nome", funcionarioAtualizar.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioAtualizar.Sobrenome);
                    cmd.Parameters.AddWithValue("@DtNascimento", funcionarioAtualizar.DataNascimento);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public void Deletar(int IdDelete)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Funcionarios WHERE IdFuncionario = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", IdDelete);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = DateTime.Parse(rdr["DataNascimento"].ToString())
                        };

                        funcionarios.Add(funcionario);
                    }

                    return funcionarios;
                }
            }
        }

        public List<FuncionarioDomain> ListarPesquisa(string Buscar)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome LIKE '%{Buscar}%' ORDER BY Nome DESC";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = DateTime.Parse(rdr["DataNascimento"].ToString())
                        };

                        funcionarios.Add(funcionario);
                    }

                    return funcionarios;
                }
            }
        }

        public List<FuncionarioDomain> ListarUnico(int IdUnico)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE IdFuncionario = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", IdUnico);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),    
                            DataNascimento = DateTime.Parse(rdr["DataNascimento"].ToString())
                        };

                        funcionarios.Add(funcionario);
                    }

                    return funcionarios;
                }
            }
        }
    }
}
