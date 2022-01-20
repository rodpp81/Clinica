using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string NomePaciente { get; set; }
        [Required(ErrorMessage = "Email do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo CPF do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        public string Senha { get; set; }
        [Display(Name = "Nome do Convenio")]
        public string IdConvenio { get; set; }

        public List<Exame> Exames { get; set; }
    }
}
