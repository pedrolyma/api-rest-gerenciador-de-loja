using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class LocalizacaoDao
    {
        public async Task<List<LocalizacaoModel>> GetLocalizacoes()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<LocalizacaoModel> listaLocalizacao = new List<LocalizacaoModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaLocalizacao";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                LocalizacaoModel objLocalizacao;
                while (reader.Read())
                {
                    objLocalizacao = new LocalizacaoModel();
                    objLocalizacao.IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"]);
                    objLocalizacao.DescricaoLocalizacao = reader["DescricaoLocalizacao"].ToString();
                    listaLocalizacao.Add(objLocalizacao);
                }
                return listaLocalizacao;
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

        public async Task<LocalizacaoModel> InserirLocalizacao(LocalizacaoModel objLocalizacao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "InsertLocalizacao";
                comando.Parameters.Add(new MySqlParameter("@DescricaoLocalizacao", objLocalizacao.DescricaoLocalizacao));
                comando.ExecuteNonQuery();
                return objLocalizacao;
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

        public async void AtualizarLocalizacao(LocalizacaoModel objLocalizacao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "UpdateLocalizacao";
                comando.Parameters.Add(new MySqlParameter("@IdLocalizacao", objLocalizacao.IdLocalizacao));
                comando.Parameters.Add(new MySqlParameter("@DescricaoLocalizacao", objLocalizacao.DescricaoLocalizacao));
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

        public void ExcluirLocalizacao(long idLocalizacao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteLocalizacao";
                comando.Parameters.Add(new MySqlParameter("@IdLocalizacao", idLocalizacao));
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

        public async Task<LocalizacaoModel> GetLocalizacaoPorId(long idLocalizacao)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_LocalizacaoPorId";
                comando.Parameters.Add(new MySqlParameter("@IdLocalizacao", idLocalizacao));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                LocalizacaoModel objLocalizacao = new LocalizacaoModel();
                while (reader.Read())
                {
                    objLocalizacao = new LocalizacaoModel();
                    objLocalizacao.IdLocalizacao = Convert.ToInt32(reader["IdLocalizacao"]);
                    objLocalizacao.DescricaoLocalizacao = reader["DescricaoLocalizacao"].ToString();
                }
                return objLocalizacao;
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
