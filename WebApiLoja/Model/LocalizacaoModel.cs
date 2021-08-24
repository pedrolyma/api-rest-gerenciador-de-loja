using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Model
{
    public class LocalizacaoModel
    {
        public long IdLocalizacao { get; set; }
        public string DescricaoLocalizacao { get; set; }
        public string StatusLocalizacao { get; set; }
    }
}
