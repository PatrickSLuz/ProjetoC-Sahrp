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
using Microsoft.AspNetCore.Authorization;

namespace ProjetoControleComprasWEB.Controllers
{
    //[Authorize(Roles = "Administrador, Gestor")]
    public class AgenteController : Controller
    {
        private readonly AgenteDAO _agenteDAO;
        private readonly CargoDAO _cargoDAO;
        private readonly SetorDAO _setorDAO;
        private readonly UserManager<AgenteLogado> _userManager;
        private readonly SignInManager<AgenteLogado> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AgenteController(AgenteDAO agenteDAO, CargoDAO cargoDAO, SetorDAO setorDAO, 
            UserManager<AgenteLogado> userManager, SignInManager<AgenteLogado> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _agenteDAO = agenteDAO;
            _cargoDAO = cargoDAO;
            _setorDAO = setorDAO;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: Agente
        public IActionResult Index()
        {
            ViewData["AgenteId"] = AgenteLogado.Autenticado.AgenteId;
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
            if (ModelState.IsValid) {
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

                    //-------------------atribuir role ao user------------------------------
                    var applicationRole = await _roleManager.FindByNameAsync(agente.Cargo.NomeCargo);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(aLogado, agente.Cargo.NomeCargo);
                    }
                    //-------------------atribuir role ao user------------------------------

                    if (_agenteDAO.Cadastrar(agente))
                    {
                        return RedirectToAction("Index");
                    }
                }
                AdicionarErros(result);
            }
            ModelState.AddModelError("","Selecione um Cargo e um Setor!");
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
        public IActionResult Edit(string usuario, int id)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.ListarTodos(), "CargoId", "NomeCargo");
            ViewBag.Setores = new SelectList(_setorDAO.ListarTodos(), "SetorId", "NomeSetor");

            if (string.IsNullOrEmpty(usuario))
            {
                if (!AgenteLogado.Autenticado.Cargo.NomeCargo.Equals("Usuario"))
                {
                    ViewData["usuario"] = "false";
                }    
            }
            else
            {
                ViewData["usuario"] = usuario;
            }

            if (AgenteLogado.Autenticado.Cargo.NomeCargo.Equals("Usuario"))
            {
                id = AgenteLogado.Autenticado.AgenteId;
            }
            return View(_agenteDAO.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Agente agente, int drpCargo, int drpSetor)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.ListarTodos(), "CargoId", "NomeCargo");
            ViewBag.Setores = new SelectList(_setorDAO.ListarTodos(), "SetorId", "NomeSetor");
            agente.Cargo = _cargoDAO.BuscarPorId(drpCargo);
            agente.Setor = _setorDAO.BuscarPorId(drpSetor);

            // Fazer Logout do Agente
            //await _signInManager.SignOutAsync();

            // Fazer update do Agente
            if (_agenteDAO.Editar(agente))
            {
                if (AgenteLogado.Autenticado.Cargo.NomeCargo.Equals("Usuario"))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                return RedirectToAction("Index");
            }
            return View(agente);
        }

        // GET: Agente/Delete/5
        public IActionResult Delete(int id)
        {
            _agenteDAO.Deletar(_agenteDAO.BuscarPorId(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
