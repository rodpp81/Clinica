using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Medico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Medico")]
        public string NomeMedico { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CRM")]
        public string Crm { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

       
        [Display(Name = "Especialidade")]
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }

        [Display(Name = "Agenda disponivel")]
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }

    }
}
