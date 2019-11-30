using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace ProjetoControleComprasWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly AgenteDAO _agenteDAO;
        private readonly UserManager<AgenteLogado> _userManager;
        private readonly SignInManager<AgenteLogado> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginController(AgenteDAO agenteDAO, UserManager<AgenteLogado> userManager, 
            SignInManager<AgenteLogado> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _agenteDAO = agenteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            AgenteLogado agLogado = new AgenteLogado
            {
                UserName = "admin@email.com",
                Email = "admin@email.com"
            };
            IdentityResult result = await _userManager.CreateAsync(agLogado, "Admin@123");
            if (result.Succeeded)
            {
                //-------------------atribuir role ao user------------------------------
                var applicationRole = await _roleManager.FindByNameAsync("Administrador");
                if (applicationRole != null)
                {
                    IdentityResult roleResult = await _userManager.AddToRoleAsync(agLogado, "Administrador");
                }
                //-------------------atribuir role ao user------------------------------
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Agente agente)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(agente.Email, agente.Senha, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("teste");
            }
            ModelState.AddModelError("", "Falha no Login!");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}