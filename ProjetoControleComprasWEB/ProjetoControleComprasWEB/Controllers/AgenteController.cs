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

namespace ProjetoControleComprasWEB.Controllers
{
    public class AgenteController : Controller
    {
        private readonly AgenteDAO _agenteDAO;
        private readonly UserManager<AgenteLogado> _userManager;
        private readonly SignInManager<AgenteLogado> _signInManager;

        public AgenteController(AgenteDAO agenteDAO, UserManager<AgenteLogado> userManager, SignInManager<AgenteLogado> signInManager)
        {
            _agenteDAO = agenteDAO;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agente agente)
        {
            // Preencher obrigatoriamente o UserName e o Email
            AgenteLogado aLogado = new AgenteLogado
            {
                UserName = agente.Email,
                Email = agente.Email
            };
            IdentityResult result = await _userManager.CreateAsync(aLogado, agente.Senha);
            if (result.Succeeded)
            {
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

            return View(_agenteDAO.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agente agente)
        {
            if (_agenteDAO.Cadastrar(agente))
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
