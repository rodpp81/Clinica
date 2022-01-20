﻿using System;
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
    public class PerfilUsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PerfilUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PerfilUsuarios
        public async Task<IActionResult> Index()
        {
            var comAacesso = await Usuario_Com_Acesso(3, _context);

            if (!comAacesso)
            {
                return RedirectToAction("index", "Home");
            }

            var applicationDbContext = _context.PerfilUsuarios.Include(p => p.IdentityUser).Include(p => p.TipoUsuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PerfilUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfilUsuario = await _context.PerfilUsuarios
                .Include(p => p.IdentityUser)
                .Include(p => p.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfilUsuario == null)
            {
                return NotFound();
            }

            return View(perfilUsuario);
        }

        // GET: PerfilUsuarios/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario");
            return View();
        }

        // POST: PerfilUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoUsuarioId,UserId")] PerfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfilUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", perfilUsuario.UserId);
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario", perfilUsuario.TipoUsuarioId);
            return View(perfilUsuario);
        }

        // GET: PerfilUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfilUsuario = await _context.PerfilUsuarios.FindAsync(id);
            if (perfilUsuario == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", perfilUsuario.UserId);
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario", perfilUsuario.TipoUsuarioId);
            return View(perfilUsuario);
        }

        // POST: PerfilUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoUsuarioId,UserId")] PerfilUsuario perfilUsuario)
        {
            if (id != perfilUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfilUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilUsuarioExists(perfilUsuario.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", perfilUsuario.UserId);
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuariosTipoUsuarios, "Id", "DescricaoTipoUsuario", perfilUsuario.TipoUsuarioId);
            return View(perfilUsuario);
        }

        // GET: PerfilUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfilUsuario = await _context.PerfilUsuarios
                .Include(p => p.IdentityUser)
                .Include(p => p.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfilUsuario == null)
            {
                return NotFound();
            }

            return View(perfilUsuario);
        }

        // POST: PerfilUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfilUsuario = await _context.PerfilUsuarios.FindAsync(id);
            _context.PerfilUsuarios.Remove(perfilUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilUsuarioExists(int id)
        {
            return _context.PerfilUsuarios.Any(e => e.Id == id);
        }
    }
}
