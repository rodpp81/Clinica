using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class TipoUsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoUsuarios
        public async Task<IActionResult> Index()
        {
            var comAacesso = await Usuario_Com_Acesso(1, _context);
            
            if(!comAacesso)
            {
                return RedirectToAction("index", "Home");
            }


            return View(await _context.TipoUsuariosTipoUsuarios.ToListAsync());
        }

        // GET: TipoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuariosTipoUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoTipoUsuario")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuariosTipoUsuarios.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoTipoUsuario")] TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUsuarioExists(tipoUsuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUsuario = await _context.TipoUsuariosTipoUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoUsuario = await _context.TipoUsuariosTipoUsuarios.FindAsync(id);
            _context.TipoUsuariosTipoUsuarios.Remove(tipoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUsuarioExists(int id)
        {
            return _context.TipoUsuariosTipoUsuarios.Any(e => e.Id == id);
        }
    }
}
