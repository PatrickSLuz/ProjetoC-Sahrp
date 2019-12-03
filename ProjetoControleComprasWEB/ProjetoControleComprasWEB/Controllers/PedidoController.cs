using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;
using ProjetoControleComprasWEB.Utils;
using Microsoft.AspNetCore.Identity;

namespace ProjetoControleComprasWEB.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly PedidoDAO _pedidoDAO;
        private readonly AgenteDAO _agenteDAO;
        private readonly UserManager<AgenteLogado> _userManager;

        public PedidoController(ProdutoDAO produtoDAO, PedidoDAO pedidoDAO, AgenteDAO agenteDAO, UserManager<AgenteLogado> userManager)
        {
            _produtoDAO = produtoDAO;
            _pedidoDAO = pedidoDAO;
            _agenteDAO = agenteDAO;
            _userManager = userManager;
        }
        
        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = new SelectList(_produtoDAO.ListarTodos(), "ProdutoId", "NomeProduto");
            return View(TempPedido.GetPedido());
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            ViewBag.Produtos = new SelectList(_produtoDAO.ListarTodos(), "ProdutoId", "NomeProduto");
            if (TempPedido.GetListaItens().Count > 0)
            {
                if (ModelState.IsValid)
                {
                    pedido.ItensPedido = TempPedido.GetListaItens();
                    string email = _userManager.GetUserName(HttpContext.User); // Pegando E-MAIL de quem esta AUTENTICADO
                    pedido.Solicitante = _agenteDAO.BuscarAgentePorEmail(email);

                    //Verificar Cargo para cadastrar o STATUS
                    if (pedido.Solicitante.Cargo.NomeCargo.Equals("Administrador") ||
                        pedido.Solicitante.Cargo.NomeCargo.Equals("Gestor"))
                    {
                        pedido.Status = StatusPedido.GetStatus(1); // Aguardando Cadastro de Orçamentos
                    }
                    else
                    {
                        pedido.Status = StatusPedido.GetStatus(0); // Aguardando Validação do Gestor
                    }

                    if (_pedidoDAO.Cadastrar(pedido))
                    {
                        TempPedido.ClearData();
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            ModelState.AddModelError("", "Favor Adicionar no Mínimo 1 Produto!");
            return View(pedido);
        }

        public IActionResult PedidosParaValidar(int setorId, string nomeSetor)
        {
            ViewData["NomeSetor"] = nomeSetor;
            return View(_pedidoDAO.ListarPedidosPorSetorEStatusIgual(setorId, StatusPedido.GetStatus(0)));
        }

        public IActionResult ListPedidosValidados(int setorId, string nomeSetor)
        {
            ViewData["NomeSetor"] = nomeSetor;
            return View(_pedidoDAO.ListarPedidosPorStatus(StatusPedido.GetStatus(1)));
        }

        public IActionResult ValidarPedido(int pedidoId)
        {
            _pedidoDAO.AtualizarStatusPedido(pedidoId, StatusPedido.GetStatus(1), null);
            return RedirectToAction("PedidosParaValidar");
        }

        public IActionResult CancelarPedido(int pedidoId)
        {
            ViewData["pedidoId"] = pedidoId;
            TempPedido.pedidoId = pedidoId;
            return View(pedidoId);
        }

        [HttpPost]
        public IActionResult CancelarPedido(int pedidoId, string motivo)
        {
            pedidoId = TempPedido.pedidoId;
            if (!string.IsNullOrEmpty(motivo))
            {
                if(_pedidoDAO.AtualizarStatusPedido(pedidoId, StatusPedido.GetStatus(3), motivo))
                {
                    string cargo = AgenteLogado.Autenticado.Cargo.NomeCargo;
                    if (cargo.Equals("Administrador"))
                        return RedirectToAction("Index", "Admin");
                    else if (cargo.Equals("Gestor"))
                        return RedirectToAction("Index", "Gestor");
                    else if (cargo.Equals("Usuario"))
                        return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Houve um Erro ao Cancelar este Pedido!");
                return View(pedidoId);
            }
            ModelState.AddModelError("", "Favor preencher o Motivo do Cancelamento!");
            return View(pedidoId);
        }

        public IActionResult AddItemPedido(Pedido p, int drpProduto)
        {
            if (drpProduto > 0)
            {
                ItemPedido item = new ItemPedido
                {
                    Produtos = _produtoDAO.BuscarPorId(drpProduto),
                    Quantidade = 1
                };
                if (!TempPedido.AddItem(item)) {
                    ModelState.AddModelError("","Produto ja Adicionado!");
                }
            }
            return RedirectToAction("Create");
        }

        public IActionResult ListItensPedido(int pedidoId)
        {
            ViewData["PedidoId"] = pedidoId;
            return View(_pedidoDAO.ListarItensPorPedidoId(pedidoId));
        }

        public IActionResult AumentarQntItemPedido(string nomeProduto)
        {
            TempPedido.MaisQuantidade(nomeProduto);
            return RedirectToAction("Create");
        }

        public IActionResult DiminuirQntItemPedido(string nomeProduto)
        {
            TempPedido.MenosQuantidade(nomeProduto);
            return RedirectToAction("Create");
        }

        public IActionResult RemoveItemPedido(string nomeProduto)
        {
            TempPedido.RemoveItem(nomeProduto);
            return RedirectToAction("Create");
        }

        // GET: Pedido/Edit/5
        public IActionResult Edit(int id)
        {
            return View(/*pedido*/);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pedido pedido)
        {
            return View(pedido);
        }
    }
}
