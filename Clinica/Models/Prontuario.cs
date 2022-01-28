using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Prontuario
    {
        public int Id { get; set; }

        [Display(Name = "Data do Agendamento")]
        public DateTime DataDisponivel { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Paciente")]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [Display(Name = "Codigo do Médico")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Anamnese")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Medicamento")]
        public List<ProntuarioMedicamento> Medicamentos { get; set; }

        
    }
}
