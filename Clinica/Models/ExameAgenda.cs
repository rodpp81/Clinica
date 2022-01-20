using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class ExameAgenda
    {
        
            public int Id { get; set; }
            public DateTime DataSolicitacao { get; set; }


            public int ExameId { get; set; }
            public ExameTipo ExameTipo { get; set; }

            public int PacienteId { get; set; }
            public Paciente Paciente { get; set; }

            public int MedicoId { get; set; }
            public Medico Medico { get; set; }

    }
}

