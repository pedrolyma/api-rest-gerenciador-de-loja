using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class MarcaDao
    {
        public async Task<List<MarcaModel>> GetMarcas()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<MarcaModel> listaMarca = new List<MarcaModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaMarca";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                MarcaModel objMarca;
                while (reader.Read())
                {
                    objMarca = new MarcaModel();
                    objMarca.IdMarca = Convert.ToInt32(reader["IdMarca"]);
                    objMarca.DescricaoMarca = reader["DescricaoMarca"].ToString();
                    objMarca.StatusMarca = reader["StatusMarca"].ToString();
                    objMarca.FotoMarca = reader["FotoMarca"].ToString();
                    listaMarca.Add(objMarca);
                }
                return listaMarca;
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

        public async Task<MarcaModel>  InserirMarca(MarcaModel objMarca)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                //comando.CommandType = CommandType.Text;
                //comando.CommandText = "INSERT INTO Tb_Marca (descricaoMarca, statusMarca, fotoMarca) values(@descricao, @status, @foto)";
                //comando.Parameters.AddWithValue("@descricao", objMarca.DescricaoMarca);
                //comando.Parameters.AddWithValue("@status", objMarca.StatusMarca);
                //comando.Parameters.AddWithValue("@foto", objMarca.FotoMarca);
                comando.CommandText = "sp_insertMarca";
                comando.Parameters.Add(new MySqlParameter("@descricaoMarca", objMarca.DescricaoMarca));
                comando.Parameters.Add(new MySqlParameter("@statusMarca", objMarca.StatusMarca));
                comando.Parameters.Add(new MySqlParameter("@fotoMarca", objMarca.FotoMarca));
                comando.ExecuteNonQuery();
                return objMarca;
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

        public async void AtualizarMarca(MarcaModel objMarca)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "UpdateMarca";
                comando.Parameters.Add(new MySqlParameter("@IdMarca", objMarca.IdMarca));
                comando.Parameters.Add(new MySqlParameter("@descricaoMarca", objMarca.DescricaoMarca));
                comando.Parameters.Add(new MySqlParameter("@statusMarca", objMarca.StatusMarca));
                comando.Parameters.Add(new MySqlParameter("@fotoMarca", objMarca.FotoMarca));
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

        public void ExcluirMarca(long idMarca)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteMarca";
                comando.Parameters.Add(new MySqlParameter("@IdMarca", idMarca));
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

        public async Task<MarcaModel> GetMarcaPorId(long idMarca)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_MarcaPorId";
                comando.Parameters.Add(new MySqlParameter("@IdMarca", idMarca));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                MarcaModel objMarca = new MarcaModel();
                while (reader.Read())
                {
                    objMarca = new MarcaModel();
                    objMarca.IdMarca = Convert.ToInt32(reader["IdMarca"]);
                    objMarca.DescricaoMarca = reader["DescricaoMarca"].ToString();
                    objMarca.StatusMarca = reader["StatusMarca"].ToString();
                    objMarca.FotoMarca = reader["FotoMarca"].ToString();
                }
                return objMarca;
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
