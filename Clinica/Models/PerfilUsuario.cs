using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class PerfilUsuario
    {
        [Display(Name = "Codigo Perfil")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Tipo Usuário")]
        [ForeignKey("TipoUsuario")]
        [Column(Order = 1)]
        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("IdentityUser")]
        [Column(Order = 1)]

        public string UserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

    }
}
