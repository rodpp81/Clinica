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
    public class ProntuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProntuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prontuarios
        public async Task<IActionResult> Index(int? PacienteId)
        {
            var comAacesso = await Usuario_Com_Acesso(2, _context);

            if (!comAacesso)

            {
                return RedirectToAction("index", "Home");
            }
            var applicationDbContext = _context.Prontuario.Where(p=>p.Paciente.Id==PacienteId).Include(p => p.Medico).Include(p => p.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prontuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .Include(p => p.Medico)
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // GET: Prontuarios/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf");
            return View();
        }

        // POST: Prontuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDisponivel,PacienteId,MedicoId,Descricao")] Prontuario prontuario,List<Medicamento>ListMedicamentos)
        {
            if (ModelState.IsValid)
            {
                foreach (var medicamento in ListMedicamentos )
                {
                    prontuario.Medicamentos.Add(new ProntuarioMedicamento()
                    {
                        Medicamento = medicamento
                    });

                }
              
                _context.Add(prontuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf", prontuario.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", prontuario.PacienteId);
            return View(prontuario);
        }

        // GET: Prontuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            //var medicos = _context.Medicos.Where(m => m.Id == User.Identity.())
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf", prontuario.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", prontuario.PacienteId);
            return View(prontuario);
        }

        // POST: Prontuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDisponivel,PacienteId,MedicoId,Descricao")] Prontuario prontuario)
        {
            if (id != prontuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioExists(prontuario.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Cpf", prontuario.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Cpf", prontuario.PacienteId);
            return View(prontuario);
        }

        // GET: Prontuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuario
                .Include(p => p.Medico)
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // POST: Prontuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prontuario = await _context.Prontuario.FindAsync(id);
            _context.Prontuario.Remove(prontuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioExists(int id)
        {
            return _context.Prontuario.Any(e => e.Id == id);
        }
    }
}
