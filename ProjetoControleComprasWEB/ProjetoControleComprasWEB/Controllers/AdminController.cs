using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ProjetoControleComprasWEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly PedidoDAO _pedidoDAO;

        public AdminController(PedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }

        public IActionResult Index()
        {
            ViewData["NomeSetor"] = AgenteLogado.Autenticado.Cargo.NomeCargo;
            return View(_pedidoDAO.ListarTodos());
        }
    }
}