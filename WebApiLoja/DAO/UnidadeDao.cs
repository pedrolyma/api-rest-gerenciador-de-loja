using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class UnidadeDao
    {
        public List<UnidadeModel> GetUnidades()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<UnidadeModel> listaUnidade = new List<UnidadeModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaUnidade";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                UnidadeModel objUnidade;
                while (reader.Read())
                {
                    objUnidade = new UnidadeModel();
                    objUnidade.IdUnidade = Convert.ToInt32(reader["IdUnidade"]);
                    objUnidade.descricaoUnidade = reader["descricaoUnidade"].ToString();
                    listaUnidade.Add(objUnidade);
                }
                return listaUnidade;
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

        public bool InserirUnidade(UnidadeModel objUnidade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_InsertUnidade";
                comando.Parameters.Add(new MySqlParameter("@descricaoUnidade", objUnidade.descricaoUnidade));
                comando.ExecuteNonQuery();
                return true;
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

        public void AtualizarUnidade(UnidadeModel objUnidade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_UpdateUnidade";
                comando.Parameters.Add(new MySqlParameter("@IdUnidade", objUnidade.IdUnidade));
                comando.Parameters.Add(new MySqlParameter("@descricaoUnidade", objUnidade.descricaoUnidade));
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

        public void ExcluirUnidade(long idUnidade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteUnidade";
                comando.Parameters.Add(new MySqlParameter("@IdUnidade", idUnidade));
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

        public UnidadeModel GetUnidadePorId(long idUnidade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UnidadePorId";
                comando.Parameters.Add(new MySqlParameter("@IdUnidade", idUnidade));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                UnidadeModel objUnidade = new UnidadeModel();
                while (reader.Read())
                {
                    objUnidade = new UnidadeModel();
                    objUnidade.IdUnidade = Convert.ToInt32(reader["IdUnidade"]);
                    objUnidade.descricaoUnidade = reader["descricaoUnidade"].ToString();
                }
                return objUnidade;
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
