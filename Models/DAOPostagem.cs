using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOPostagem
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source .\SQLEXPRESS; initial catalog = Forum; user id=sa; password=senai@123";

        public List<Postagem> Listar(){
            List<Postagem> postagens = new List<Postagem>();
            try{
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from postagem";
                rd = cmd.ExecuteReader();
                while(rd.Read()){
                    postagens.Add(new Postagem{
                        Id = rd.GetInt32(0),
                        IdTopico = rd.GetInt32(1),
                        IdUsuario = rd.GetInt32(2),
                        Mensagem = rd.GetString(3),
                        DataPublicacao = rd.GetDateTime(4)
                    });
                }
            } catch (SqlException se){
                throw new Exception(se.Message);
            } catch (Exception e){
                throw new Exception(e.Message);
            } finally {
                con.Close();
            }

            return postagens;
        }

        
    }
}