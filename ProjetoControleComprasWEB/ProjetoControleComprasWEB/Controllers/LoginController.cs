using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using ProjetoControleComprasWEB.Utils;
using Repository;

namespace ProjetoControleComprasWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly AgenteDAO _agenteDAO;

        public LoginController(AgenteDAO agenteDAO)
        {
            _agenteDAO = agenteDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar(Agente agente)
        {
            Agente ag = new Agente();
            ag.Login = agente.Login;
            ag = _agenteDAO.BuscarAgentePorLogin(ag);

            if (ag != null)
            {
                if (ag.Login.Equals(agente.Login) && ag.Senha.Equals(agente.Senha))
                {
                    VerificarCargoESetor(ag);
                }
                else
                {
                    //Usuário e/ou Senha incorretos. Tente novamente!
                }
            }
            else
            {
                //Usuário não Encontrado. Verifique!
            }

            return RedirectToAction(nameof(Index));
        }

        private void VerificarCargoESetor(Agente ag)
        {
            if (ag.Cargo.NomeCargo.Equals("Administrador"))
            {
                // Logar como Admin
                return; // parar a verificacao - vai pro fim do metodo
            }
            if (ag.Cargo.NomeCargo.Equals("Usuario"))
            {
                // Logar como Usuario
                VerificarPrimeiraSenha(ag);
                return; // parar a verificacao - vai pro fim do metodo
            }
            if (ag.Cargo.NomeCargo.Equals("Gestor"))
            {
                // Logar como Gestor
                VerificarPrimeiraSenha(ag);
                return; // parar a verificacao - vai pro fim do metodo
            }
        }

        private void VerificarPrimeiraSenha(Agente ag)
        {
            string senhaPadrao = SenhaPadrao.CriarSenhaPadrao(ag);

            if (ag.Senha.Equals(senhaPadrao))
            {
                // Tela Cadaastro de Senha
            }
        }
    }
}