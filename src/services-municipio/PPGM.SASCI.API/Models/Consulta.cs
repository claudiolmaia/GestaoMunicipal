using System;
using System.ComponentModel.DataAnnotations;

namespace PPGM.SASCI.API.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public string CPF { get; set; }
        public string Medico { get; set; }
        public string Unidade { get; set; }
        public int Consultorio { get; set; }
        public DateTime DataConsulta { get; set; }

    }
}
