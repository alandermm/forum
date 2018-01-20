using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public class DAOTopico
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        SqlDataReader rd = null;

        string conexao = @"Data Source = .\SqlExpress; Initial Catalog = Forum; user id=sa;password=senai@123";
        public List<Topico> Listar()
        {
            List<Topico> topicos = new List<Topico>();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Topico";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    topicos.Add(new Topico()
                    {
                        Id = rd.GetInt32(0),
                        Titulo = rd.GetString(1),
                        Descricao = rd.GetString(2),
                        DataCadastro = rd.GetDateTime(3)
                    });
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return topicos;
        }


        public bool Cadastro(Topico topico)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into topicoforum(titulo, descricao, datacadastro) values(@t, @d, @h)";
                cmd.Parameters.AddWithValue("@n", cidades.Nome);
                cmd.Parameters.AddWithValue("@e", cidades.Estado);
                cmd.Parameters.AddWithValue("@h", cidades.Habitantes);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            } catch(SqlException se){
                throw new Exception(se.Message);
            } catch(Exception e){
                throw new Exception(e.Message);
            } finally{
                con.Close();
            }
            return resultado;
        }

        public string Editar(Cidades cidade){
            SqlConnection con = new SqlConnection(conexao);

            string msg;

            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update Cidades set nome = @n, estado = @e, habitantes = @h where id = @id";
                cmd.Parameters.AddWithValue("@n", cidade.Nome);
                cmd.Parameters.AddWithValue("@e", cidade.Estado);
                cmd.Parameters.AddWithValue("@h", cidade.Habitantes);
                cmd.Parameters.AddWithValue("@id", cidade.Id);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if(r > 0){
                    msg = "Atualização Efetuada";
                } else {
                    msg = "Não foi possível atualizar";
                }
                cmd.Parameters.Clear();
            } catch (SqlException se){
                throw new Exception("Erro ao tentar atualizar dados" + se.Message);
            } catch (System.Exception e){
                throw new Exception("Erro inesperado" + e.Message);
                throw;
            } finally {
                con.Close();
            }

            return msg;
        }

        public bool Apagar(int id)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Cidades where id = @i";
                cmd.Parameters.AddWithValue("@i", id);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            } catch(SqlException se){
                throw new Exception(se.Message);
            } catch(Exception e){
                throw new Exception(e.Message);
            } finally{
                con.Close();
            }
            return resultado;
        }
    }
    }
}