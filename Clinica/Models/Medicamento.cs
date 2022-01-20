using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do Medicamento é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Medicamento")]
        public string NomeMedicamento { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Generico")]
        public string NomeGenerico { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Fabricante")]
        public string NomeFabrica { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de Fabricação")]
        public DateTime DataFabricacao { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de vencimento")]
        public DateTime DataVencimento { get; set; }

        public List<Receita> Receitas { get; set; }
    }
}
