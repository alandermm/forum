using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models {
    public class DAOTopico{
        SqlConnection con = null;
        SqlCommand cmd = null;

        SqlDataReader rd = null;

        string conexao = @"Data Source = .\SqlExpress; Initial Catalog = Forum; user id=sa;password=senai@123";
        public List<Topico> Listar(){
            List<Topico> topicos = new List<Topico>();
            try{
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Topico";
                rd = cmd.ExecuteReader();
                while (rd.Read()){
                    topicos.Add(new Topico(){
                        Id = rd.GetInt32(0),
                        Titulo = rd.GetString(1),
                        Descricao = rd.GetString(2),
                        DataCadastro = rd.GetDateTime(3)
                    });
                }
            }catch (SqlException se){
                throw new Exception("Erro ao tentar mostrar dados " + se.Message);
            }catch (Exception ex){
                throw new Exception("Erro inesperado " + ex.Message);
            } finally{
                con.Close();
            }
            return topicos;
        }


        public bool Cadastrar(Topico topico){
            bool resultado = false;
            try{
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into topicoforum(titulo, descricao, datacadastro) values(@t, @des, @dc)";
                cmd.Parameters.AddWithValue("@t", topico.Titulo);
                cmd.Parameters.AddWithValue("@des", topico.Descricao);
                cmd.Parameters.AddWithValue("@dc", DateTime.Now);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            } catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar dados " +se.Message);
            } catch(Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally{
                con.Close();
            }
            return resultado;
        }

        public bool Editar(Topico topico){

            bool resultado = false;

            try{
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update topicoforum set titulo = @t, descricao = @des where id = @id";
                cmd.Parameters.AddWithValue("@t", topico.Titulo);
                cmd.Parameters.AddWithValue("@des", topico.Descricao);
                cmd.Parameters.AddWithValue("@id", topico.Id);
                
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;
                cmd.Parameters.Clear();
            } catch (SqlException se){
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            } catch (System.Exception e){
                throw new Exception("Erro inesperado " + e.Message);
                throw;
            } finally {
                con.Close();
            }

            return resultado;
        }

        public bool Apagar(int id){
            bool resultado = false;
            try{
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from topicoforum where id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            } catch(SqlException se){
                throw new Exception("Erro ao tentar deletar dados " + se.Message);
            } catch(Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally{
                con.Close();
            }
            return resultado;
        }
    }
}