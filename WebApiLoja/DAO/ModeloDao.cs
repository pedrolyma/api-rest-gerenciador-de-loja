using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class ModeloDao
    {
        public async Task<List<ModeloModel>> GetModelos()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<ModeloModel> listaModelo = new List<ModeloModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaModelo";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                ModeloModel objModelo;
                while (reader.Read())
                {
                    objModelo = new ModeloModel();
                    objModelo.idModelo = Convert.ToInt32(reader["idModelo"]);
                    objModelo.descricaoModelo = reader["descricaoModelo"].ToString();
                    objModelo.statusModelo = reader["statusModelo"].ToString();
                    objModelo.id_Secao = Convert.ToInt32(reader["id_Secao"]);
                    listaModelo.Add(objModelo);
                }
                return listaModelo;
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

        public async Task<ModeloModel> InserirModelo(ModeloModel objModelo)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_insertModelo";
                comando.Parameters.Add(new MySqlParameter("@descricaoModelo", objModelo.descricaoModelo));
                comando.Parameters.Add(new MySqlParameter("@statusModelo", objModelo.statusModelo));
                comando.Parameters.Add(new MySqlParameter("@id_secao", objModelo.id_Secao));
                comando.ExecuteNonQuery();
                return objModelo;
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

        public async Task<ModeloModel> AtualizarModelo(ModeloModel objModelo)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_updateModelo";
                comando.Parameters.Add(new MySqlParameter("@idModelo", objModelo.idModelo));
                comando.Parameters.Add(new MySqlParameter("@descricaoModelo", objModelo.descricaoModelo));
                comando.Parameters.Add(new MySqlParameter("@statusModelo", objModelo.statusModelo));
                comando.Parameters.Add(new MySqlParameter("@id_secao", objModelo.id_Secao));
                comando.ExecuteNonQuery();
                return objModelo;
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

        public void ExcluirModelo(long idModelo)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_deleteModelo";
                comando.Parameters.Add(new MySqlParameter("@idModelo", idModelo));
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

        public async Task<ModeloModel> GetModeloPorId(long idModelo)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_modeloPorId";
                comando.Parameters.Add(new MySqlParameter("@idModelo", idModelo));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                ModeloModel objModelo = new ModeloModel();
                while (reader.Read())
                {
                    objModelo = new ModeloModel();
                    objModelo.idModelo = Convert.ToInt32(reader["idModelo"]);
                    objModelo.descricaoModelo = reader["descricaoModelo"].ToString();
                    objModelo.statusModelo = reader["statusModelo"].ToString();
                    objModelo.id_Secao = Convert.ToInt32(reader["id_Secao"]);
                }
                return objModelo;
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
