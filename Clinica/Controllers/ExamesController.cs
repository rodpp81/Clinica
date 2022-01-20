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
    public class ExamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Exames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Exame.Include(e => e.Medico).Include(e => e.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Exames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exame
                .Include(e => e.Medico)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // GET: Exames/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf");
            return View();
        }

        // POST: Exames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataSolicitacao,TipoExameId,PacienteId,MedicoId")] Exame exame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id", exame.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", exame.PacienteId);
            return View(exame);
        }

        // GET: Exames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exame.FindAsync(id);
            if (exame == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id", exame.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", exame.PacienteId);
            return View(exame);
        }

        // POST: Exames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataSolicitacao,TipoExameId,PacienteId,MedicoId")] Exame exame)
        {
            if (id != exame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExameExists(exame.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Id", exame.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", exame.PacienteId);
            return View(exame);
        }

        // GET: Exames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exame
                .Include(e => e.Medico)
                .Include(e => e.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exame = await _context.Exame.FindAsync(id);
            _context.Exame.Remove(exame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExameExists(int id)
        {
            return _context.Exame.Any(e => e.Id == id);
        }
    }
}
