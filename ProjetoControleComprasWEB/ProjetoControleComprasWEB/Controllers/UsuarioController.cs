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
    public class UsuarioController : Controller
    {
        private readonly PedidoDAO _pedidoDAO;

        public UsuarioController(PedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
        }
        public IActionResult Index()
        {
            // Verificar quem esta Autenticado
            // pera pegar o Setor
            ViewData["NomeSetor"] = AgenteLogado.Autenticado.Setor.NomeSetor;
            List<Pedido> listaPedidosPorAgenteEStatus = _pedidoDAO.ListarPedidosDeUsuario(AgenteLogado.Autenticado.AgenteId);
            if (listaPedidosPorAgenteEStatus.Count() >= 1)
            {
                ViewData["newPedido"] = "false";
            }
            else
            {
                ViewData["newPedido"] = "true";
            }
            return View(_pedidoDAO.ListarPedidosPorAgente(AgenteLogado.Autenticado.AgenteId));
        }
    }
}