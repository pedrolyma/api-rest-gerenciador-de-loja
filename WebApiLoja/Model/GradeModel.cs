using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLoja.Model
{
    public class GradeModel
    {
        public int idGrade { get; set; }
        public string inicioGrade { get; set; }
        public string fimGrade { get; set; }
        public string intervalo { get; set; }
        public int qtdeItensGrade { get; set; }
    }
}
