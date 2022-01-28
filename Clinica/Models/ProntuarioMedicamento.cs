using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class ProntuarioMedicamento
    {
        public int Id { get; set; }
        public Prontuario Prontuario { get; set; }
        public  Medicamento Medicamento { get; set; }

    }
}
