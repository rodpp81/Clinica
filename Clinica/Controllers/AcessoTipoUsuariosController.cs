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
    public class AcessoTipoUsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AcessoTipoUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcessoTipoUsuarios
        public async Task<IActionResult> Index()
        {
            var comAacesso = await Usuario_Com_Acesso(2, _context);

            if (!comAacesso)
            
            {
                return RedirectToAction("index", "Home");
            }

            var applicationDbContext = _context.AcessoTipoUsuarios.Include(a => a.TipoUsuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AcessoTipoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoTipoUsuario = await _context.AcessoTipoUsuarios
                .Include(a => a.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoTipoUsuario == null)
            {
                return NotFound();
            }

            return View(acessoTipoUsuario);
        }

        // GET: AcessoTipoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario");
            return View();
        }

        // POST: AcessoTipoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFuncionalidade,TipoUsuarioId")] AcessoTipoUsuario acessoTipoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessoTipoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario", acessoTipoUsuario.TipoUsuarioId);
            return View(acessoTipoUsuario);
        }

        // GET: AcessoTipoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoTipoUsuario = await _context.AcessoTipoUsuarios.FindAsync(id);
            if (acessoTipoUsuario == null)
            {
                return NotFound();
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario", acessoTipoUsuario.TipoUsuarioId);
            return View(acessoTipoUsuario);
        }

        // POST: AcessoTipoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFuncionalidade,TipoUsuarioId")] AcessoTipoUsuario acessoTipoUsuario)
        {
            if (id != acessoTipoUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessoTipoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessoTipoUsuarioExists(acessoTipoUsuario.Id))
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
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario", acessoTipoUsuario.TipoUsuarioId);
            return View(acessoTipoUsuario);
        }

        // GET: AcessoTipoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessoTipoUsuario = await _context.AcessoTipoUsuarios
                .Include(a => a.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acessoTipoUsuario == null)
            {
                return NotFound();
            }

            return View(acessoTipoUsuario);
        }

        // POST: AcessoTipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessoTipoUsuario = await _context.AcessoTipoUsuarios.FindAsync(id);
            _context.AcessoTipoUsuarios.Remove(acessoTipoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessoTipoUsuarioExists(int id)
        {
            return _context.AcessoTipoUsuarios.Any(e => e.Id == id);
        }
    }
}
