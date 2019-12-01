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
    public class GestorController : Controller
    {
        private readonly PedidoDAO _pedidoDAO;
        private readonly AgenteDAO _agenteDAO;

        public GestorController(PedidoDAO pedidoDAO, AgenteDAO agenteDAO)
        {
            _pedidoDAO = pedidoDAO;
            _agenteDAO = agenteDAO;
        }

        public IActionResult Index()
        {
            // Verificar quem esta Autenticado
            // pera pegar o Setor
            ViewData["NomeSetor"] = AgenteLogado.Autenticado.Setor.NomeSetor;
            ViewData["SetorId"] = AgenteLogado.Autenticado.Setor.SetorId;

            return View(_pedidoDAO.ListarPedidosPorSetor(AgenteLogado.Autenticado.Setor.SetorId));
        }
    }
}