using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Models;

namespace Clinica.Data
{
    public class ExameTipoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExameTipoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExameTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExameTipos.ToListAsync());
        }

        // GET: ExameTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exameTipo = await _context.ExameTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exameTipo == null)
            {
                return NotFound();
            }

            return View(exameTipo);
        }

        // GET: ExameTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExameTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] ExameTipo exameTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exameTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exameTipo);
        }

        // GET: ExameTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exameTipo = await _context.ExameTipos.FindAsync(id);
            if (exameTipo == null)
            {
                return NotFound();
            }
            return View(exameTipo);
        }

        // POST: ExameTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] ExameTipo exameTipo)
        {
            if (id != exameTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exameTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExameTipoExists(exameTipo.Id))
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
            return View(exameTipo);
        }

        // GET: ExameTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exameTipo = await _context.ExameTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exameTipo == null)
            {
                return NotFound();
            }

            return View(exameTipo);
        }

        // POST: ExameTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exameTipo = await _context.ExameTipos.FindAsync(id);
            _context.ExameTipos.Remove(exameTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExameTipoExists(int id)
        {
            return _context.ExameTipos.Any(e => e.Id == id);
        }
    }
}
