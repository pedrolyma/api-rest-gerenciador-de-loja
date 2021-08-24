using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.Model;

namespace WebApiLoja.DAO
{
    public class ProdutoDao
    {
        public async Task<List<ProdutoModel>> listaProdutos()
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                List<ProdutoModel> listaProduto = new List<ProdutoModel>();
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_listaProduto";
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                ProdutoModel objProduto;
                while (reader.Read())
                {
                    objProduto = new ProdutoModel();
                    objProduto.idProduto = Convert.ToInt32(reader["idProduto"]);
                    objProduto.descricaoProduto = reader["descricaoProduto"].ToString();
                    objProduto.referenciaProduto = reader["referenciaProduto"].ToString();
                    objProduto.codigoBarraProduto = reader["codigoBarraProduto"].ToString();
                    objProduto.generoProduto = reader["generoProduto"].ToString();
                    objProduto.ncmshProduto = reader["ncmshProduto"].ToString();
                    objProduto.statusProduto = reader["statusProduto"].ToString();
                    objProduto.id_secao = Convert.ToInt32(reader["id_secao"]);
                    objProduto.id_modelo = Convert.ToInt32(reader["id_modelo"]);
                    objProduto.id_cor = Convert.ToInt32(reader["id_cor"]);
                    objProduto.id_marca = Convert.ToInt32(reader["id_marca"]);
                    objProduto.id_grade = Convert.ToInt32(reader["id_grade"]);
                    objProduto.id_unidade = Convert.ToInt32(reader["id_unidade"]);
                    objProduto.id_localizacao = Convert.ToInt32(reader["id_localizacao"]);
                    objProduto.id_fornecedor = Convert.ToInt32(reader["id_fornecedor"]);
                    objProduto.dataCadastro = Convert.ToDateTime(reader["dataCadastro"].ToString());
                    objProduto.informacoes = reader["informacoes"].ToString();
                    objProduto.fotoProduto1 = reader["fotoProduto1"].ToString();
                    objProduto.fotoProduto2 = reader["fotoProduto2"].ToString();
                    objProduto.fotoProduto3 = reader["fotoProduto3"].ToString();
                    objProduto.saldoAtual = Convert.ToDecimal(reader["saldoAtual"]);
                    objProduto.saldoMinimo = Convert.ToDecimal(reader["saldoMinimo"]);
                    objProduto.valorCusto = Convert.ToDecimal(reader["valorCusto"]);
                    objProduto.valorImposto = Convert.ToDecimal(reader["valorImposto"]);
                    objProduto.valorFrete = Convert.ToDecimal(reader["valorFrete"]);
                    objProduto.valorDesconto = Convert.ToDecimal(reader["valorDesconto"]);
                    objProduto.margemGanho = Convert.ToDecimal(reader["margemGanho"]);
                    objProduto.vendaVista = Convert.ToDecimal(reader["vendaVista"]);
                    objProduto.vendaPrazo = Convert.ToDecimal(reader["vendaPrazo"]);
                    objProduto.vendaPromocao = Convert.ToDecimal(reader["vendaPromocao"]);
                    objProduto.pesoProduto = Convert.ToDecimal(reader["pesoProduto"]);
                    listaProduto.Add(objProduto);
                }
                return listaProduto;
                ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task<ProdutoModel> InserirProduto(ProdutoModel objProduto)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_insertProduto";
                comando.Parameters.Add(new MySqlParameter("@descricaoProduto", objProduto.descricaoProduto));
                comando.Parameters.Add(new MySqlParameter("@referenciaProduto", objProduto.referenciaProduto));
                comando.Parameters.Add(new MySqlParameter("@codigoBarraProduto", objProduto.codigoBarraProduto));
                comando.Parameters.Add(new MySqlParameter("@generoProduto", objProduto.generoProduto));
                comando.Parameters.Add(new MySqlParameter("@ncmshProduto", objProduto.ncmshProduto));
                comando.Parameters.Add(new MySqlParameter("@statusProduto", objProduto.statusProduto));
                comando.Parameters.Add(new MySqlParameter("@id_secao", objProduto.id_secao));
                comando.Parameters.Add(new MySqlParameter("@id_modelo", objProduto.id_modelo));
                comando.Parameters.Add(new MySqlParameter("@id_cor", objProduto.id_cor));
                comando.Parameters.Add(new MySqlParameter("@id_marca", objProduto.id_marca));
                comando.Parameters.Add(new MySqlParameter("@id_grade", objProduto.id_grade));
                comando.Parameters.Add(new MySqlParameter("@id_unidade", objProduto.id_unidade));
                comando.Parameters.Add(new MySqlParameter("@id_localizacao", objProduto.id_localizacao));
                comando.Parameters.Add(new MySqlParameter("@id_fornecedor", objProduto.id_fornecedor));
                comando.Parameters.Add(new MySqlParameter("@dataCadastro", objProduto.dataCadastro));
                comando.Parameters.Add(new MySqlParameter("@informacoes", objProduto.informacoes));
                comando.Parameters.Add(new MySqlParameter("@fotoProduto1", objProduto.fotoProduto1));
                comando.Parameters.Add(new MySqlParameter("@fotoProduto2", objProduto.fotoProduto2));
                comando.Parameters.Add(new MySqlParameter("@fotoProduto3", objProduto.fotoProduto3));
                comando.Parameters.Add(new MySqlParameter("@saldoAtual", objProduto.saldoAtual));
                comando.Parameters.Add(new MySqlParameter("@saldoMinimo", objProduto.saldoMinimo));
                comando.Parameters.Add(new MySqlParameter("@valorCusto", objProduto.valorCusto));
                comando.Parameters.Add(new MySqlParameter("@valorImposto", objProduto.valorImposto));
                comando.Parameters.Add(new MySqlParameter("@valorFrete", objProduto.valorFrete));
                comando.Parameters.Add(new MySqlParameter("@valorDesconto", objProduto.valorDesconto));
                comando.Parameters.Add(new MySqlParameter("@margemGanho", objProduto.margemGanho));
                comando.Parameters.Add(new MySqlParameter("@vendaVista", objProduto.vendaVista));
                comando.Parameters.Add(new MySqlParameter("@vendaPrazo", objProduto.vendaPrazo));
                comando.Parameters.Add(new MySqlParameter("@vendaPromocao", objProduto.vendaPromocao));
                comando.Parameters.Add(new MySqlParameter("@pesoProduto", objProduto.pesoProduto));
                comando.ExecuteNonQuery();
                return objProduto;
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

        public async Task<ProdutoModel> AlterarProduto(ProdutoModel objProduto)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "Sp_updateProduto";
                comando.Parameters.Add(new MySqlParameter("@idProduto", objProduto.idProduto));
                comando.Parameters.Add(new MySqlParameter("@descricaoProduto", objProduto.descricaoProduto));
                comando.Parameters.Add(new MySqlParameter("@referenciaProduto", objProduto.referenciaProduto));
                comando.Parameters.Add(new MySqlParameter("@codigoBarraProduto", objProduto.codigoBarraProduto));
                comando.Parameters.Add(new MySqlParameter("@generoProduto", objProduto.generoProduto));
                comando.Parameters.Add(new MySqlParameter("@ncmshProduto", objProduto.ncmshProduto));
                comando.Parameters.Add(new MySqlParameter("@statusProduto", objProduto.statusProduto));
                comando.Parameters.Add(new MySqlParameter("@id_secao", objProduto.id_secao));
                comando.Parameters.Add(new MySqlParameter("@id_modelo", objProduto.id_modelo));
                comando.Parameters.Add(new MySqlParameter("@id_cor", objProduto.id_cor));
                comando.Parameters.Add(new MySqlParameter("@id_marca", objProduto.id_marca));
                comando.Parameters.Add(new MySqlParameter("@id_grade", objProduto.id_grade));
                comando.Parameters.Add(new MySqlParameter("@id_unidade", objProduto.id_unidade));
                comando.Parameters.Add(new MySqlParameter("@id_localizacao", objProduto.id_localizacao));
                comando.Parameters.Add(new MySqlParameter("@id_fornecedor", objProduto.id_fornecedor));
                comando.Parameters.Add(new MySqlParameter("@dataCadastro", objProduto.dataCadastro));
                comando.Parameters.Add(new MySqlParameter("@informacoes", objProduto.informacoes));
                comando.Parameters.Add(new MySqlParameter("@fotoProduto1", objProduto.fotoProduto1));
                comando.Parameters.Add(new MySqlParameter("@fotoProduto2", objProduto.fotoProduto2));
                comando.Parameters.Add(new MySqlParameter("@fotoProduto3", objProduto.fotoProduto3));
                comando.Parameters.Add(new MySqlParameter("@saldoAtual", objProduto.saldoAtual));
                comando.Parameters.Add(new MySqlParameter("@saldoMinimo", objProduto.saldoMinimo));
                comando.Parameters.Add(new MySqlParameter("@valorCusto", objProduto.valorCusto));
                comando.Parameters.Add(new MySqlParameter("@valorImposto", objProduto.valorImposto));
                comando.Parameters.Add(new MySqlParameter("@valorFrete", objProduto.valorFrete));
                comando.Parameters.Add(new MySqlParameter("@valorDesconto", objProduto.valorDesconto));
                comando.Parameters.Add(new MySqlParameter("@margemGanho", objProduto.margemGanho));
                comando.Parameters.Add(new MySqlParameter("@vendaVista", objProduto.vendaVista));
                comando.Parameters.Add(new MySqlParameter("@vendaPrazo", objProduto.vendaPrazo));
                comando.Parameters.Add(new MySqlParameter("@vendaPromocao", objProduto.vendaPromocao));
                comando.Parameters.Add(new MySqlParameter("@pesoProduto", objProduto.pesoProduto));
                comando.ExecuteNonQuery();
                return objProduto;
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

        public void ExcluirProduto(long idProduto)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_deleteProduto";
                comando.Parameters.Add(new MySqlParameter("@idProduto", idProduto));
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

        public async Task<ProdutoModel> GetProdutoPorId(long idProduto)
        {
            MySqlConnection conexao = Conexao.GetConexao();
            try
            {
                MySqlCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_produtoPorId";
                comando.Parameters.Add(new MySqlParameter("@idProduto", idProduto));
                comando.ExecuteNonQuery();
                MySqlDataReader reader = Conexao.GetDataReader(comando);
                ProdutoModel objProduto = new ProdutoModel();
                while (reader.Read())
                {
                    objProduto = new ProdutoModel();
                    objProduto.idProduto = Convert.ToInt32(reader["idProduto"]);
                    objProduto.descricaoProduto = reader["descricaoProduto"].ToString();
                    objProduto.referenciaProduto = reader["referenciaProduto"].ToString();
                    objProduto.codigoBarraProduto = reader["codigoBarraProduto"].ToString();
                    objProduto.generoProduto = reader["generoProduto"].ToString();
                    objProduto.ncmshProduto = reader["ncmshProduto"].ToString();
                    objProduto.statusProduto = reader["statusProduto"].ToString();
                    objProduto.id_secao = Convert.ToInt32(reader["id_secao"]);
                    objProduto.id_modelo = Convert.ToInt32(reader["id_modelo"]);
                    objProduto.id_cor = Convert.ToInt32(reader["id_cor"]);
                    objProduto.id_marca = Convert.ToInt32(reader["id_marca"]);
                    objProduto.id_grade = Convert.ToInt32(reader["id_grade"]);
                    objProduto.id_unidade = Convert.ToInt32(reader["id_unidade"]);
                    objProduto.id_localizacao = Convert.ToInt32(reader["id_localizacao"]);
                    objProduto.id_fornecedor = Convert.ToInt32(reader["id_fornecedor"]);
                    objProduto.dataCadastro = Convert.ToDateTime(reader["dataCadastro"].ToString());
                    objProduto.informacoes = reader["informacoes"].ToString();
                    objProduto.fotoProduto1 = reader["fotoProduto1"].ToString();
                    objProduto.fotoProduto2 = reader["fotoProduto2"].ToString();
                    objProduto.fotoProduto3 = reader["fotoProduto3"].ToString();
                    objProduto.saldoAtual = Convert.ToDecimal(reader["saldoAtual"]);
                    objProduto.saldoMinimo = Convert.ToDecimal(reader["saldoMinimo"]);
                    objProduto.valorCusto = Convert.ToDecimal(reader["valorCusto"]);
                    objProduto.valorImposto = Convert.ToDecimal(reader["valorImposto"]);
                    objProduto.valorFrete = Convert.ToDecimal(reader["valorFrete"]);
                    objProduto.valorDesconto = Convert.ToDecimal(reader["valorDesconto"]);
                    objProduto.margemGanho = Convert.ToDecimal(reader["margemGanho"]);
                    objProduto.vendaVista = Convert.ToDecimal(reader["vendaVista"]);
                    objProduto.vendaPrazo = Convert.ToDecimal(reader["vendaPrazo"]);
                    objProduto.vendaPromocao = Convert.ToDecimal(reader["vendaPromocao"]);
                    objProduto.pesoProduto = Convert.ToDecimal(reader["pesoProduto"]);
                }
                return objProduto;
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
