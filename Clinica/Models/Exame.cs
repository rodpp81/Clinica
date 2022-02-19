using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Exame
    {
        public int Id { get; set; }

        public DateTime DataSolicitacao{ get; set; }

        public byte resultExame { get; set; }

        public int TipoExameId { get; set; }
        public ExameTipo ExameTipo { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
               
    }
}
