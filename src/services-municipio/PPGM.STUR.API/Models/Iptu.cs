using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGM.STUR.API.Models
{
    public class Iptu
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public decimal Valor { get; set; }
        public int Exercicio { get; set; }
        public bool IsPago { get; set; }
    }
}

