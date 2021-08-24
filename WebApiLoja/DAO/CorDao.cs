using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class CorDao
    {
        public async Task<List<CorModel>> GetCores()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<CorModel> listaCor = new List<CorModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaCor";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                CorModel objCor;
                while (reader.Read())
                {
                    objCor = new CorModel();
                    objCor.IdCor = Convert.ToInt32(reader["IdCor"]);
                    objCor.DescricaoCor = reader["descricaoCor"].ToString();
                    listaCor.Add(objCor);
                }
                return listaCor;
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

        public async Task<CorModel> InserirCor(CorModel objCor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO Tb_Cores(descricaoCor) values (@descricao)";
                comando.Parameters.AddWithValue("@descricao", objCor.DescricaoCor);
                comando.ExecuteNonQuery();
                return objCor;
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

        public async void AtualizarCor(CorModel objCor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "UpdateCor";
                comando.Parameters.Add(new MySqlParameter("@IdCor", objCor.IdCor));
                comando.Parameters.Add(new MySqlParameter("@descricaoCor", objCor.DescricaoCor));
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

        public void ExcluirCor(long idCor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteCor";
                comando.Parameters.Add(new MySqlParameter("@IdCor", idCor));
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

        public async Task<CorModel> GetCorPorId(long idCor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_CorPorId";
                comando.Parameters.Add(new MySqlParameter("@IdCor", idCor));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                CorModel objCor = new CorModel();
                while (reader.Read())
                {
                    objCor = new CorModel();
                    objCor.IdCor = Convert.ToInt32(reader["IdCor"]);
                    objCor.DescricaoCor = reader["descricaoCor"].ToString();
                }
                return objCor;
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
