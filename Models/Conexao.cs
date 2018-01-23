using System.Data.SqlClient;

namespace Forum.Models
{
    public abstract class Conexao
    {
        /// <summary>
        /// Objeto utilizado para estabelecer a conexão
        /// com o servidor de banco de dados SQLExpress.
        /// </summary>
        protected SqlConnection con = null;

        /// <summary>
        /// Objeto utilizado para executar comandos de SQL, tais como:
        /// Select; Update; Delete; Insert e outros.
        /// </summary>
        protected SqlCommand cmd = null;

        /// <summary>
        /// Objeto utilizado para guardar os retornos do select
        /// realizados nas tabelas do banco de dados
        /// </summary>
        protected SqlDataReader rd = null;

        /// <summary>
        /// O método Path retorna o local do bando de dados.
        /// </summary>
        /// <returns>Retorna uma string para conexão com o banco de dados.</returns>
        protected static string Path(){
            return @"Data Source = .\SQLEXPRESS; initial catalog = Forum; user id = sa; password=senai@123";
        }
    }
}