using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;

namespace Clinica.Models
{
    public class ExameAgendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExameAgendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExameAgendas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExameAgendas.Include(e => e.Medico).Include(e => e.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExameAgendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exameAgenda = await _context.ExameAgendas
                .Include(e => e.Medico)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exameAgenda == null)
            {
                return NotFound();
            }

            return View(exameAgenda);
        }

        // GET: ExameAgendas/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomePaciente");
            return View();
        }

        // POST: ExameAgendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataSolicitacao,ExameId,PacienteId,MedicoId")] ExameAgenda exameAgenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exameAgenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf", exameAgenda.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", exameAgenda.PacienteId);
            return View(exameAgenda);
        }

        // GET: ExameAgendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exameAgenda = await _context.ExameAgendas.FindAsync(id);
            if (exameAgenda == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf", exameAgenda.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", exameAgenda.PacienteId);
            return View(exameAgenda);
        }

        // POST: ExameAgendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataSolicitacao,ExameId,PacienteId,MedicoId")] ExameAgenda exameAgenda)
        {
            if (id != exameAgenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exameAgenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExameAgendaExists(exameAgenda.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf", exameAgenda.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", exameAgenda.PacienteId);
            return View(exameAgenda);
        }

        // GET: ExameAgendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exameAgenda = await _context.ExameAgendas
                .Include(e => e.Medico)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exameAgenda == null)
            {
                return NotFound();
            }

            return View(exameAgenda);
        }

        // POST: ExameAgendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exameAgenda = await _context.ExameAgendas.FindAsync(id);
            _context.ExameAgendas.Remove(exameAgenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExameAgendaExists(int id)
        {
            return _context.ExameAgendas.Any(e => e.Id == id);
        }
    }
}
