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
        private readonly PedidoDAO _pedidoDAO;

        public OrcamentoController(OrcamentoDAO orcamentoDAO, PedidoDAO pedidoDAO)
        {
            _orcamentoDAO = orcamentoDAO;
            _pedidoDAO = pedidoDAO;
        }

        // GET: Orcamento
        public IActionResult Index(int pedidoId)
        {
            ViewData["PedidoId"] = pedidoId;
            return View(_pedidoDAO.ListarOrcamentosPorPedido(pedidoId));
        }

        // GET: Orcamento/Create
        public IActionResult Create(int pedidoId)
        {
            ViewData["PedidoId"] = pedidoId;
            return View();
        }

        // POST: Orcamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }

        // GET: Orcamento/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orcamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }

        // GET: Orcamento/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orcamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
