using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class AgendaMedica
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Medico")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        [Display(Name = "Data do Agendamento")]
        public DateTime DataDisponivel { get; set; }


    }
}
