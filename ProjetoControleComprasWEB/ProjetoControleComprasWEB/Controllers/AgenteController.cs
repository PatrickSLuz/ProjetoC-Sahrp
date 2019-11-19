using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;

namespace ProjetoControleComprasWEB.Controllers
{
    public class AgenteController : Controller
    {
        private readonly AgenteDAO _agenteDAO;

        public AgenteController(AgenteDAO agenteDAO)
        {
            _agenteDAO = agenteDAO;
        }

        // GET: Agente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agentes.ToListAsync());
        }

        // GET: Agente/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agente agente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agente);
        }

        // GET: Agente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }
            return View(agente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Agente agente)
        {
            if (id != agente.AgenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenteExists(agente.AgenteId))
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
            return View(agente);
        }

        // GET: Agente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agentes
                .FirstOrDefaultAsync(m => m.AgenteId == id);
            if (agente == null)
            {
                return NotFound();
            }

            return View(agente);
        }

        // POST: Agente/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agente = await _context.Agentes.FindAsync(id);
            _context.Agentes.Remove(agente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
