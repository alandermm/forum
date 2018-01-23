using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOPostagem:Conexao
    {
        
        public List<Postagem> Listar(){
            List<Postagem> postagens = new List<Postagem>();
            try{
                con = new SqlConnection(Path());
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from postagem";
                SqlDataReader rd = cmd.ExecuteReader();
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
                throw new Exception("Erro ao tentar listar os dados " + se.Message);
            } catch (Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally {
                con.Close();
            }

            return postagens;
        }

        public bool Cadastrar(Postagem postagem){
            bool resultado = false;

            try{
                con = new SqlConnection(Path());
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into postagem (idtopico, idusuario, mensagem, datapublicacao) values (@idt, @idu, @m, @dp)";
                cmd.Parameters.AddWithValue("@idt", postagem.IdTopico);
                cmd.Parameters.AddWithValue("@idu", postagem.IdUsuario);
                cmd.Parameters.AddWithValue("@m", postagem.Mensagem.ToString());
                cmd.Parameters.AddWithValue("@dp", DateTime.Now);
                int r = cmd.ExecuteNonQuery();          
                if(r > 0)
                    resultado = true;
                cmd.Parameters.Clear();
            }catch (SqlException se){
                throw new Exception("Erro ao tentar cadastrar os dados " + se.Message);
            }catch (Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally {
                con.Close();
            }
            return resultado;
        }

        public bool Editar(Postagem postagem){
            bool resultado = false;

            try{
                con = new SqlConnection(Path());
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update postagem set idtopico = @idt, idusuario = @idu, mensagem = @m Where id = @id";
                cmd.Parameters.AddWithValue("@idt", postagem.IdTopico);
                cmd.Parameters.AddWithValue("@idu", postagem.IdUsuario);
                cmd.Parameters.AddWithValue("@m", postagem.Mensagem.ToString());
                cmd.Parameters.AddWithValue("@id", postagem.Id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;
                cmd.Parameters.Clear();
            }catch (SqlException se){
                throw new Exception("Erro ao tentar atualizar os dados " + se.Message);
            }catch (Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            }finally{
                con.Close();
            }
            return resultado;
        }

        public bool Apagar(int id){
            bool resultado = false;

            try{
                con = new SqlConnection(Path());
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from postagem Where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;
                cmd.Parameters.Clear();
            } catch (SqlException se){
                throw new Exception("Erro ao tentar deletar os dados " + se.Message);
            } catch (Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally {
                con.Close();
            }
            return resultado;
        }
    }
}