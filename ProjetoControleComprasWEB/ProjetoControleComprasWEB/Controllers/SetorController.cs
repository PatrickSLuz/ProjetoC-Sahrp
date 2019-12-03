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
    public class SetorController : Controller
    {
        private readonly SetorDAO _setorDAO;

        public SetorController(SetorDAO setorDAO)
        {
            _setorDAO = setorDAO;
        }

        // GET: Setor
        public IActionResult Index()
        {
            return View(_setorDAO.ListarTodos());
        }

        // GET: Setor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Setor setor)
        {
            if (ModelState.IsValid)
            {
                if (_setorDAO.Cadastrar(setor))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("","Esse Setor ja Existe!");
            }
            return View(setor);
        }

        // GET: Setor/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_setorDAO.BuscarPorId(id));
        }

        // POST: Setor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Setor setor)
        {
            if (ModelState.IsValid)
            {
                if (_setorDAO.Editar(setor))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Esse Setor ja Existe!");
            }
            return View(setor);
        }

        // GET: Setor/Delete/5
        public IActionResult Delete(int id)
        {
            _setorDAO.Deletar(_setorDAO.BuscarPorId(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
