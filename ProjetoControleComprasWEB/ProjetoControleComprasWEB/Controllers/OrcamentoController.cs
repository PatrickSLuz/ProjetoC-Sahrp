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
    public class OrcamentoController : Controller
    {
        private readonly OrcamentoDAO _orcamentoDAO;

        public OrcamentoController(OrcamentoDAO orcamentoDAO)
        {
            _orcamentoDAO = orcamentoDAO;
        }

        // GET: Orcamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orcamentos.ToListAsync());
        }

        // GET: Orcamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orcamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrcamentoId,NomeEmpresa,CpfCnpjFornecedor,Valor,Descricao,DtCriacao")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }

        // GET: Orcamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos.FindAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return View(orcamento);
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Orcamento orcamento)
        {
            if (id != orcamento.OrcamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoExists(orcamento.OrcamentoId))
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
            return View(orcamento);
        }

        // GET: Orcamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos
                .FirstOrDefaultAsync(m => m.OrcamentoId == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // POST: Orcamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orcamento = await _context.Orcamentos.FindAsync(id);
            _context.Orcamentos.Remove(orcamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
