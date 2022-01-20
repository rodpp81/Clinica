using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataReceita { get; set; }

        public int MedicamentoId { get; set; }
        public Medicamento Medicamento { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

    }
}
