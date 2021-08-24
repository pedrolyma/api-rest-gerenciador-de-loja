using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class FornecedorDao
    {
        public async Task<List<FornecedorModel>> listaFornecedor()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<FornecedorModel> listaFornecedor = new List<FornecedorModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaFornecedor";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                FornecedorModel objFornecedor;
                while (reader.Read())
                {
                    objFornecedor = new FornecedorModel();
                    objFornecedor.IdFornecedor = Convert.ToInt32(reader["IdFornecedor"]);
                    objFornecedor.RazaoSocial = reader["RazaoSocial"].ToString();
                    objFornecedor.NomeFantasia = reader["NomeFantasia"].ToString();
                    objFornecedor.CepFornecedor = reader["CepFornecedor"].ToString();
                    objFornecedor.LogradouroFornecedor = reader["LogradouroFornecedor"].ToString();
                    objFornecedor.BairroFornecedor = reader["BairroFornecedor"].ToString();
                    objFornecedor.CidadeFornecedor = reader["CidadeFornecedor"].ToString();
                    objFornecedor.EstadoFornecedor = reader["EstadoFornecedor"].ToString();
                    objFornecedor.SiteFornecedor = reader["SiteFornecedor"].ToString();
                    objFornecedor.EmailFornecedor = reader["EmailFornecedor"].ToString();
                    objFornecedor.TelefoneFornecedor = reader["TelefoneFornecedor"].ToString();
                    objFornecedor.WhatsAppFornecedor = reader["WhatsAppFornecedor"].ToString();
                    objFornecedor.BancoFornecedor = reader["BancoFornecedor"].ToString();
                    objFornecedor.AgenciaFornecedor = reader["AgenciaFornecedor"].ToString();
                    objFornecedor.ContaFornecedor = reader["ContaFornecedor"].ToString();
                    objFornecedor.TitularFornecedor = reader["TitularFornecedor"].ToString();
                    objFornecedor.MercadoriaFornecedor = reader["MercadoriaFornecedor"].ToString();
                    objFornecedor.ObservacaoFornecedor = reader["ObservacaoFornecedor"].ToString();
                    objFornecedor.StatusFornecedor = reader["StatusFornecedor"].ToString();
                    objFornecedor.PixFornecedor = reader["PixFornecedor"].ToString();
                    listaFornecedor.Add(objFornecedor);
                }
                return listaFornecedor;
;            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            } 
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task<bool> InserirFornecedor(FornecedorModel objFornecedor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_insertFornecedor";
                comando.Parameters.Add(new MySqlParameter("@RazaoSocial", objFornecedor.RazaoSocial));
                comando.Parameters.Add(new MySqlParameter("@NomeFantasia", objFornecedor.NomeFantasia));
                comando.Parameters.Add(new MySqlParameter("@CepFornecedor", objFornecedor.CepFornecedor));
                comando.Parameters.Add(new MySqlParameter("@LogradouroFornecedor", objFornecedor.LogradouroFornecedor));
                comando.Parameters.Add(new MySqlParameter("@BairroFornecedor", objFornecedor.BairroFornecedor));
                comando.Parameters.Add(new MySqlParameter("@CidadeFornecedor", objFornecedor.CidadeFornecedor));
                comando.Parameters.Add(new MySqlParameter("@EstadoFornecedor", objFornecedor.EstadoFornecedor));
                comando.Parameters.Add(new MySqlParameter("@SiteFornecedor", objFornecedor.SiteFornecedor));
                comando.Parameters.Add(new MySqlParameter("@EmailFornecedor", objFornecedor.EmailFornecedor));
                comando.Parameters.Add(new MySqlParameter("@TelefoneFornecedor", objFornecedor.TelefoneFornecedor));
                comando.Parameters.Add(new MySqlParameter("@WhatsAppFornecedor", objFornecedor.WhatsAppFornecedor));
                comando.Parameters.Add(new MySqlParameter("@BancoFornecedor", objFornecedor.BancoFornecedor));
                comando.Parameters.Add(new MySqlParameter("@AgenciaFornecedor", objFornecedor.AgenciaFornecedor));
                comando.Parameters.Add(new MySqlParameter("@ContaFornecedor", objFornecedor.ContaFornecedor));
                comando.Parameters.Add(new MySqlParameter("@TitularFornecedor", objFornecedor.TitularFornecedor));
                comando.Parameters.Add(new MySqlParameter("@MercadoriaFornecedor", objFornecedor.MercadoriaFornecedor));
                comando.Parameters.Add(new MySqlParameter("@ObservacaoFornecedor", objFornecedor.ObservacaoFornecedor));
                comando.Parameters.Add(new MySqlParameter("@StatusFornecedor", objFornecedor.StatusFornecedor));
                comando.Parameters.Add(new MySqlParameter("@PixFornecedor", objFornecedor.PixFornecedor));
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

        public async Task AlterarFornecedor(FornecedorModel objFornecedor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_updateFornecedor";
                comando.Parameters.Add(new MySqlParameter("@IdFornecedor", objFornecedor.IdFornecedor));
                comando.Parameters.Add(new MySqlParameter("@RazaoSocial", objFornecedor.RazaoSocial));
                comando.Parameters.Add(new MySqlParameter("@NomeFantasia", objFornecedor.NomeFantasia));
                comando.Parameters.Add(new MySqlParameter("@CepFornecedor", objFornecedor.CepFornecedor));
                comando.Parameters.Add(new MySqlParameter("@LogradouroFornecedor", objFornecedor.LogradouroFornecedor));
                comando.Parameters.Add(new MySqlParameter("@BairroFornecedor", objFornecedor.BairroFornecedor));
                comando.Parameters.Add(new MySqlParameter("@CidadeFornecedor", objFornecedor.CidadeFornecedor));
                comando.Parameters.Add(new MySqlParameter("@EstadoFornecedor", objFornecedor.EstadoFornecedor));
                comando.Parameters.Add(new MySqlParameter("@SiteFornecedor", objFornecedor.SiteFornecedor));
                comando.Parameters.Add(new MySqlParameter("@EmailFornecedor", objFornecedor.EmailFornecedor));
                comando.Parameters.Add(new MySqlParameter("@TelefoneFornecedor", objFornecedor.TelefoneFornecedor));
                comando.Parameters.Add(new MySqlParameter("@WhastAppFornecedor", objFornecedor.WhatsAppFornecedor));
                comando.Parameters.Add(new MySqlParameter("@BancoFornecedor", objFornecedor.BancoFornecedor));
                comando.Parameters.Add(new MySqlParameter("@AgenciaFornecedor", objFornecedor.AgenciaFornecedor));
                comando.Parameters.Add(new MySqlParameter("@ContaFornecedor", objFornecedor.ContaFornecedor));
                comando.Parameters.Add(new MySqlParameter("@TitularFornecedor", objFornecedor.TitularFornecedor));
                comando.Parameters.Add(new MySqlParameter("@MercadoriaFornecedor", objFornecedor.MercadoriaFornecedor));
                comando.Parameters.Add(new MySqlParameter("@ObservacaoFornecedor", objFornecedor.ObservacaoFornecedor));
                comando.Parameters.Add(new MySqlParameter("@StatusFornecedor", objFornecedor.StatusFornecedor));
                comando.Parameters.Add(new MySqlParameter("@PixFornecedor", objFornecedor.PixFornecedor));
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

        public void ExcluirFornecedor(long idFornecedor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteFornecedor";
                comando.Parameters.Add(new MySqlParameter("@IdFornecedor", idFornecedor));
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

        public async Task<FornecedorModel> GetFornecedorPorId(long idFornecedor)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_FornecedorPorId";
                comando.Parameters.Add(new MySqlParameter("@IdFornecedor", idFornecedor));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                FornecedorModel objFornecedor = new FornecedorModel();
                while (reader.Read())
                {
                    objFornecedor = new FornecedorModel();
                    objFornecedor.IdFornecedor = Convert.ToInt32(reader["IdFornecedor"]);
                    objFornecedor.RazaoSocial = reader["RazaoSocial"].ToString();
                    objFornecedor.NomeFantasia = reader["NomeFantasia"].ToString();
                    objFornecedor.CepFornecedor = reader["CepFornecedor"].ToString();
                    objFornecedor.LogradouroFornecedor = reader["LogradouroFornecedor"].ToString();
                    objFornecedor.BairroFornecedor = reader["BairroFornecedor"].ToString();
                    objFornecedor.CidadeFornecedor = reader["CidadeFornecedor"].ToString();
                    objFornecedor.EstadoFornecedor = reader["EstadoFornecedor"].ToString();
                    objFornecedor.SiteFornecedor = reader["SiteFornecedor"].ToString();
                    objFornecedor.EmailFornecedor = reader["EmailFornecedor"].ToString();
                    objFornecedor.TelefoneFornecedor = reader["TelefoneFornecedor"].ToString();
                    objFornecedor.WhatsAppFornecedor = reader["WhatsAppFornecedor"].ToString();
                    objFornecedor.BancoFornecedor = reader["BancoFornecedor"].ToString();
                    objFornecedor.AgenciaFornecedor = reader["AgenciaFornecedor"].ToString();
                    objFornecedor.ContaFornecedor = reader["ContaFornecedor"].ToString();
                    objFornecedor.TitularFornecedor = reader["TitularFornecedor"].ToString();
                    objFornecedor.MercadoriaFornecedor = reader["MercadoriaFornecedor"].ToString();
                    objFornecedor.ObservacaoFornecedor = reader["ObservacaoFornecedor"].ToString();
                    objFornecedor.StatusFornecedor = reader["StatusFornecedor"].ToString();
                    objFornecedor.PixFornecedor = reader["PixFornecedor"].ToString();
                }
                return objFornecedor;
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
