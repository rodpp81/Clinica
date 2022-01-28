using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class ExameAgenda
    {
        
            public int Id { get; set; }
            public DateTime DataSolicitacao { get; set; }
            [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
            [Display(Name = "Código do Exame")]
            public int ExameId { get; set; }
            public ExameTipo ExameTipo { get; set; }

            [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
            [Display(Name = "Nome do Paciente")]
            public int PacienteId { get; set; }
            public Paciente Paciente { get; set; }

         
            [Display(Name = "Codigo do Médico")]
            public int MedicoId { get; set; }
            public Medico Medico { get; set; }

    }
}

