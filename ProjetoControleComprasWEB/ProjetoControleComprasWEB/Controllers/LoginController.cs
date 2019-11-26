using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoControleComprasWEB.Utils;
using Repository;

namespace ProjetoControleComprasWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly AgenteDAO _agenteDAO;
        private readonly UserManager<AgenteLogado> _userManager;
        private readonly SignInManager<AgenteLogado> _signInManager;

        public LoginController(AgenteDAO agenteDAO, UserManager<AgenteLogado> userManager, SignInManager<AgenteLogado> signInManager)
        {
            _agenteDAO = agenteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logar(Agente agente)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(agente.Email, agente.Senha, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ver");
            }
            ModelState.AddModelError("", "Falha no Login!");
            return View();
        }
    }
}