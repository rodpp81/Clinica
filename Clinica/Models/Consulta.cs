using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Sobre a consulta")]
        public string Descricao { get; set; }
        public DateTime DataAgendamento { get; set; }

        [Display(Name = "Nome do Paciente")]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [Display(Name = "Nome do Medico")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

    }
}
