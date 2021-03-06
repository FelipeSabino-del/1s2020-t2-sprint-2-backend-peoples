﻿using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tipos = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        tipos.Add(tipoUsuario);
                    }
                    return tipos;
                }
            }
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario WHERE IdTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "UPDATE TipoUsuario SET Titulo = @Titulo WHERE IdTipoUsuario = @ID;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", TipoUsuarioAtualizado.Titulo);
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                }
            }
        }


        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "DELETE TipoUsuario WHERE IdTipoUsuario = @ID;";

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
