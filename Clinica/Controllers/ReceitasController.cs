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
    public class ReceitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Receita.Include(r => r.Medicamento).Include(r => r.Medico).Include(r => r.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(r => r.Medicamento)
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "NomeMedicamento");
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomePaciente");
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DataReceita,MedicamentoId,PacienteId,MedicoId")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "NomeMedicamento", receita.MedicamentoId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico", receita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomePaciente", receita.PacienteId);
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "NomeMedicamento", receita.MedicamentoId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico", receita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomePaciente", receita.PacienteId);
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataReceita,MedicamentoId,PacienteId,MedicoId")] Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "NomeMedicamento", receita.MedicamentoId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "NomeMedico", receita.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomePaciente", receita.PacienteId);
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(r => r.Medicamento)
                .Include(r => r.Medico)
                .Include(r => r.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _context.Receita.FindAsync(id);
            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }
    }
}
