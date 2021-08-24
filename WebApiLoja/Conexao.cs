using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja
{
    public class Conexao
    {
        private IConfiguration configuration;
        private string connectionString { get; }
        public Conexao(IConfiguration _configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            configuration = _configuration;
        }
        public static MySqlConnection GetConexao()
        {
            string connection = "Server=localhost;Database=dbloja;user=root;password=505035";
            try
            {
                MySqlConnection conexao = new MySqlConnection(connection);
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static MySqlCommand GetComando(MySqlConnection conecao)
        {
            MySqlCommand comando = conecao.CreateCommand();
            return comando;
        }

        public static MySqlDataReader GetDataReader(MySqlCommand comando)
        {
            return comando.ExecuteReader();
        }

        public static void FechaConecao(MySqlConnection conecao)
        {
            conecao.Close();
        }
    }
}
