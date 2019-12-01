using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(_pedidoDAO.ListarTodos());
        }
    }
}