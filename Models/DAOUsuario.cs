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
                throw new Exception("Erro ao tentar mostrar dados " +se.Message);
            } catch (Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally {
                con.Close();
            }
            return usuarios;
        }

        public bool Cadastrar(Usuario usuario){
            bool resultado = false;
            try{
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into usuario(nome, login, senha, datacadastro) values (@n, @l, @s, @dc)";
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);
                cmd.Parameters.AddWithValue("@dc", DateTime.Now);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar dados " +se.Message);
            }catch(Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally {
                con.Close();
            }
            return resultado;
        }

        public bool Editar(Usuario usuario){
            bool resultado = false;

            try{
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update usuario set nome = @n, login = @l, senha = @s Where id = @id";
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                
                int r = cmd.ExecuteNonQuery();

                if(r > 0)
                    resultado = true;
    
                cmd.Parameters.Clear();
            }catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            }catch(Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally{
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
                cmd.CommandText = "Delete from usuario where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    resultado = true;
                cmd.Parameters.Clear();
            } catch (SqlException se){
                throw new Exception("Erro ao tentar deletar dados " + se.Message);
            } catch (Exception e){
                throw new Exception("Erro inesperado " + e.Message);
            } finally {
                con.Close();
            }
            return resultado;
        }
    }
}