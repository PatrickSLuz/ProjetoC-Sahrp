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
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;

        public ProdutoController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        // GET: Produto
        public IActionResult Index()
        {
            return View(_produtoDAO.ListarTodos());
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(produto))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Esse Produto ja Existe!");
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_produtoDAO.BuscarPorId(id));
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Editar(produto))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Esse Produto ja Existe!");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public IActionResult Delete(int id)
        {
            _produtoDAO.Deletar(_produtoDAO.BuscarPorId(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
