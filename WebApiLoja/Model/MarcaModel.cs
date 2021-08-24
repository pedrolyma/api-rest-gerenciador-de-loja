using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Model
{
    public class MarcaModel
    {
        public long IdMarca { get; set; }
        [Required(ErrorMessage = "A Descricao da Marca Não Pode Ficar Vazia")]
        [StringLength(150, ErrorMessage = "A Descricao da Marca deve Ter de 2 a 150 Caracteres", MinimumLength = 2)]
        public string DescricaoMarca { get; set; }
        public string StatusMarca { get; set; }
        public string FotoMarca { get; set; }
    }
}
