using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Controllers
{   
    [Authorize]
    public class ControllerBase : Controller
    {
        public async Task <bool> Usuario_Com_Acesso (int codePage, Data.ApplicationDbContext context)
        {
            var usuario = User.Identity.Name;

            var comAcesso = await (from TP in context.TipoUsuariosTipoUsuarios
                                   join AT in context.AcessoTipoUsuarios on TP.Id equals AT.TipoUsuarioId
                                   join PF in context.PerfilUsuarios on TP.Id equals PF.TipoUsuarioId
                                   join US in context.Usuario on PF.UserId equals US.Id
                                   where AT.Id == codePage && US.Email == usuario
                                   select new
                                   {
                                       TP.Id
                                   }).AnyAsync();
            return comAcesso;


        }
    }
}
