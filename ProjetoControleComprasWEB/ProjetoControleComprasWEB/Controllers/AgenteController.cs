using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;
using Microsoft.AspNetCore.Identity;
using ProjetoControleComprasWEB.Utils;

namespace ProjetoControleComprasWEB.Controllers
{
    public class AgenteController : Controller
    {
        private readonly AgenteDAO _agenteDAO;
        private readonly CargoDAO _cargoDAO;
        private readonly SetorDAO _setorDAO;
        private readonly UserManager<AgenteLogado> _userManager;
        private readonly SignInManager<AgenteLogado> _signInManager;

        public AgenteController(AgenteDAO agenteDAO, CargoDAO cargoDAO, SetorDAO setorDAO, UserManager<AgenteLogado> userManager, SignInManager<AgenteLogado> signInManager)
        {
            _agenteDAO = agenteDAO;
            _cargoDAO = cargoDAO;
            _setorDAO = setorDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Agente
        public async Task<IActionResult> Index()
        {
            return View(_agenteDAO.ListarTodos());
        }

        // GET: Agente/Create
        public IActionResult Create()
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.ListarTodos(), "CargoId", "NomeCargo");
            ViewBag.Setores = new SelectList(_setorDAO.ListarTodos(), "SetorId", "NomeSetor");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agente agente, int drpCargo, int drpSetor)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.ListarTodos(), "CargoId", "NomeCargo");
            ViewBag.Setores = new SelectList(_setorDAO.ListarTodos(), "SetorId", "NomeSetor");
            agente.Senha = SenhaPadrao.CriarSenhaPadrao(agente);
            // Preencher obrigatoriamente o UserName e o Email
            AgenteLogado aLogado = new AgenteLogado
            {
                UserName = agente.Email,
                Email = agente.Email
            };
            IdentityResult result = await _userManager.CreateAsync(aLogado, agente.Senha);
            if (result.Succeeded)
            {
                agente.Cargo = _cargoDAO.BuscarPorId(drpCargo);
                agente.Setor = _setorDAO.BuscarPorId(drpSetor);
                if (_agenteDAO.Cadastrar(agente))
                {
                    return RedirectToAction("Index");
                }
            }
            AdicionarErros(result);
            return View();
        }

        private void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        // GET: Agente/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.ListarTodos(), "CargoId", "NomeCargo");
            ViewBag.Setores = new SelectList(_setorDAO.ListarTodos(), "SetorId", "NomeSetor");
            return View(_agenteDAO.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agente agente, int drpCargo, int drpSetor)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.ListarTodos(), "CargoId", "NomeCargo");
            ViewBag.Setores = new SelectList(_setorDAO.ListarTodos(), "SetorId", "NomeSetor");
            agente.Cargo = _cargoDAO.BuscarPorId(drpCargo);
            agente.Setor = _setorDAO.BuscarPorId(drpSetor);
            if (_agenteDAO.Editar(agente))
            {
                return RedirectToAction("Index");
            }
            return View(agente);
        }

        // GET: Agente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return RedirectToAction(nameof(Index));
        }

        // POST: Agente/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
