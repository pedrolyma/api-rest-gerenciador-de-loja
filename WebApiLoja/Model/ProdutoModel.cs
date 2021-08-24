using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Model
{
    public class ProdutoModel
    {
        public long idProduto { get; set; }
        public string descricaoProduto { get; set; }
        public string referenciaProduto { get; set; }
        public string codigoBarraProduto { get; set; }
        public string generoProduto { get; set; }
        public string ncmshProduto { get; set; }
        public string statusProduto { get; set; }
        public int id_secao { get; set; }
        public int id_modelo { get; set; }
        public int id_cor { get; set; }
        public int id_marca { get; set; }
        public int id_grade { get; set; }
        public int id_unidade { get; set; }
        public int id_localizacao { get; set; }
        public int id_fornecedor { get; set; }
        public DateTime dataCadastro { get; set; }
        public string informacoes { get; set; }
        public string fotoProduto1 { get; set; }
        public string fotoProduto2 { get; set; }
        public string fotoProduto3 { get; set; }
        public decimal saldoAtual { get; set; }
        public decimal saldoMinimo { get; set; }
        public decimal valorCusto { get; set; }
        public decimal valorImposto { get; set; }
        public decimal valorFrete { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal margemGanho { get; set; }
        public decimal vendaVista { get; set; }
        public decimal vendaPrazo { get; set; }
        public decimal vendaPromocao { get; set; }
        public decimal pesoProduto { get; set; }
    }
}
