using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.BFF.Integracao.Models
{
    public class ConsultaDTO
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Medico { get; set; }
        public string Unidade { get; set; }
        public int Consultorio { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}
