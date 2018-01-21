using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOUsuario
    {
        SqlConnection con = null;

        SqlCommand cmd = null;

        SqlDataReader rd = null;

        string conexao = @"Data Source = .\SQLEXPRESS; initial catalog = Forum; user id = sa; password=senai@123";

        public List<Usuario> Listar(){
            List<Usuario> usuarios = new List<Usuario>();

            try{
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from usuario";
                rd = cmd.ExecuteReader();
                while(rd.Read()){
                    usuarios.Add(new Usuario(){
                        Id = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Login = rd.GetString(2),
                        Senha = rd.GetString(3),
                        DataCadastro = rd.GetDateTime(4)
                    });
                }
            }catch (SqlException se){
                throw new Exception(se.Message);
            } catch (Exception e){
                throw new Exception(e.Message);
            } finally {
                con.Close();
            }
            return usuarios;
        }
    }
}