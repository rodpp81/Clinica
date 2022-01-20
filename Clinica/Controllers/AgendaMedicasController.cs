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
    public class AgendaMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendaMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AgendaMedicas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AgendaMedicas.Include(a => a.Medico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AgendaMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaMedica = await _context.AgendaMedicas
                .Include(a => a.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaMedica == null)
            {
                return NotFound();
            }

            return View(agendaMedica);
        }

        // GET: AgendaMedicas/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico");
            return View();
        }

        // POST: AgendaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicoId,DataDisponivel")] AgendaMedica agendaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico", agendaMedica.MedicoId);
            return View(agendaMedica);
        }

        // GET: AgendaMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaMedica = await _context.AgendaMedicas.FindAsync(id);
            if (agendaMedica == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico", agendaMedica.MedicoId);
            return View(agendaMedica);
        }

        // POST: AgendaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicoId,DataDisponivel")] AgendaMedica agendaMedica)
        {
            if (id != agendaMedica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaMedicaExists(agendaMedica.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico", agendaMedica.MedicoId);
            return View(agendaMedica);
        }

        // GET: AgendaMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaMedica = await _context.AgendaMedicas
                .Include(a => a.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaMedica == null)
            {
                return NotFound();
            }

            return View(agendaMedica);
        }

        // POST: AgendaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendaMedica = await _context.AgendaMedicas.FindAsync(id);
            _context.AgendaMedicas.Remove(agendaMedica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaMedicaExists(int id)
        {
            return _context.AgendaMedicas.Any(e => e.Id == id);
        }
    }
}
