using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class SecaoDao
    {
        public async Task<List<SecaoModel>> GetSecoes()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<SecaoModel> listaSecao = new List<SecaoModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaSecao";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                SecaoModel objSecao;
                while (reader.Read())
                {
                    objSecao = new SecaoModel();
                    objSecao.IdSecao = Convert.ToInt32(reader["IdSecao"]);
                    objSecao.DescricaoSecao = reader["DescricaoSecao"].ToString();
                    objSecao.StatusSecao = reader["StatusSecao"].ToString();
                    listaSecao.Add(objSecao);
                }
                return listaSecao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task<SecaoModel> InserirSecao(SecaoModel objSecao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Tb_Secao(descricaoSecao, statusSecao) values(@descricao, @status)";
                comando.Parameters.AddWithValue("@descricao", objSecao.DescricaoSecao);
                comando.Parameters.AddWithValue("@status", '1');
                comando.ExecuteNonQuery();
                return objSecao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async void AtualizarSecao(SecaoModel objSecao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "UpdateSecao";
                comando.Parameters.Add(new MySqlParameter("@IdSecao", objSecao.IdSecao));
                comando.Parameters.Add(new MySqlParameter("@descricaoSecao", objSecao.DescricaoSecao));
                comando.Parameters.Add(new MySqlParameter("@statusSecao", objSecao.StatusSecao));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public void ExcluirSecao(long idSecao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteSecao";
                comando.Parameters.Add(new MySqlParameter("@IdSecao", idSecao));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task<SecaoModel> GetSecaoPorId(long idSecao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_SecaoPorId";
                comando.Parameters.Add(new MySqlParameter("@IdSecao", idSecao));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                SecaoModel objSecao = new SecaoModel();
                while (reader.Read())
                {
                    objSecao = new SecaoModel();
                    objSecao.IdSecao = Convert.ToInt32(reader["IdSecao"]);
                    objSecao.DescricaoSecao = reader["DescricaoSecao"].ToString();
                    objSecao.StatusSecao = reader["StatusSecao"].ToString();
                }
                return objSecao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }
    }
}
