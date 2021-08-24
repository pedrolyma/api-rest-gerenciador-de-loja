using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Model
{
    public class ModeloModel
    {
        public int idModelo { get; set; }
        public string descricaoModelo { get; set; }
        public string statusModelo { get; set; }
        public int id_Secao { get; set; }
    }
}
