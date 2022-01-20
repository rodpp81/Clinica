using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    
    public class TipoUsuario
    {
        [Display(Name = "Codigo")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Tipo Usuário")]
        [Column("DescricaoTipoUsuario")]
        public string DescricaoTipoUsuario { get; set; }

        public List<AcessoTipoUsuario> AcessoTipoUsuarios { get; set; }
    }
}
