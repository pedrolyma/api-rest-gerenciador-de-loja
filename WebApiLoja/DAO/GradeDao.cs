using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class GradeDao
    {
        public async Task<List<GradeModel>> GetGrades()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<GradeModel> listaGrade = new List<GradeModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaGrade";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                GradeModel objGrade;
                while (reader.Read())
                {
                    objGrade = new GradeModel();
                    objGrade.idGrade = Convert.ToInt32(reader["idGrade"]);
                    objGrade.inicioGrade = reader["inicioGrade"].ToString();
                    objGrade.fimGrade = reader["fimGrade"].ToString();
                    objGrade.intervalo = reader["intervalo"].ToString();
                    objGrade.qtdeItensGrade = Convert.ToInt32(reader["qtdeItensGrade"]);
                    listaGrade.Add(objGrade);
                }
                return listaGrade;
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

        public async Task<GradeModel> InserirGrade(GradeModel objGrade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandText = "SP_insertGrade";
                comando.Parameters.Add(new MySqlParameter("@inicioGrade", objGrade.inicioGrade));
                comando.Parameters.Add(new MySqlParameter("@fimGrade", objGrade.fimGrade));
                comando.Parameters.Add(new MySqlParameter("@intervalo", objGrade.intervalo));
                comando.Parameters.Add(new MySqlParameter("@qtdeItensGrade", objGrade.qtdeItensGrade));
                comando.ExecuteNonQuery();
                return objGrade;
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

        public async void AtualizarGrade(GradeModel objGrade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_updateGrade";
                comando.Parameters.Add(new MySqlParameter("@idGrade", objGrade.idGrade));
                comando.Parameters.Add(new MySqlParameter("@inicioGrade", objGrade.inicioGrade));
                comando.Parameters.Add(new MySqlParameter("@fimGrade", objGrade.fimGrade));
                comando.Parameters.Add(new MySqlParameter("@intervalo", objGrade.intervalo));
                comando.Parameters.Add(new MySqlParameter("@qtdeItensGrade", objGrade.qtdeItensGrade));
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

        public void ExcluirGrade(long idGrade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_deleteGrade";
                comando.Parameters.Add(new MySqlParameter("@idGrade", idGrade));
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

        public async Task<GradeModel> GetGradePorId(long idGrade)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_gradePorId";
                comando.Parameters.Add(new MySqlParameter("@idGrade", idGrade));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                GradeModel objGrade = new GradeModel();
                while (reader.Read())
                {
                    objGrade = new GradeModel();
                    objGrade.idGrade = Convert.ToInt32(reader["idGrade"]);
                    objGrade.inicioGrade = reader["inicioGrade"].ToString();
                    objGrade.fimGrade = reader["fimGrade"].ToString();
                    objGrade.intervalo = reader["intervalo"].ToString();
                    objGrade.qtdeItensGrade = Convert.ToInt32(reader["qtdeItensGrade"]);
                }
                return objGrade;
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
