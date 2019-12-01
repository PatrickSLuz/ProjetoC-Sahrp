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
    public class CargoController : Controller
    {
        private readonly CargoDAO _cargoDAO;

        public CargoController(CargoDAO cargoDAO)
        {
            _cargoDAO = cargoDAO;
        }

        // GET: Cargo
        public IActionResult Index()
        {
            return View(_cargoDAO.ListarTodos());
        }
        
        // GET: Cargo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                if (_cargoDAO.Cadastrar(cargo))
                {
                    return RedirectToAction(nameof(Index), nameof(Cargo));
                }
                ModelState.AddModelError("","Esse Cargo ja Existe!");
            }
            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_cargoDAO.BuscarPorId(id));
        }

        // POST: Cargo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                if (_cargoDAO.Editar(cargo))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Esse Cargo ja Existe!");
            }
            return View(cargo);
        }
        
        // GET: Cargo/Delete/5
        public IActionResult Delete(int id)
        {     
            _cargoDAO.Deletar(_cargoDAO.BuscarPorId(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
