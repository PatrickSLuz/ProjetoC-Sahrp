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
            // Verificar quem esta Autenticado
            // pera pegar o Setor
            ViewData["NomeSetor"] = AgenteLogado.Autenticado.Setor.NomeSetor;
            ViewData["SetorId"] = AgenteLogado.Autenticado.Setor.SetorId;
            return View(_pedidoDAO.ListarTodos());
        }
    }
}