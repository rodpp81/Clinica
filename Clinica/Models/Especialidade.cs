using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Especialidade Médica")]
        public string Descricao { get; set; }

        public List<Medico> Medicos { get; set; }

    }
}
