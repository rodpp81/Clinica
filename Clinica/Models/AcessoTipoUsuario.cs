using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class AcessoTipoUsuario
    {
        [Display(Name = "Codigo")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Column("NomeFuncionalidade")]
        public string NomeFuncionalidade { get; set; }

        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public List<PerfilUsuario> PerfilUsuarios { get; set; }
    }
}
