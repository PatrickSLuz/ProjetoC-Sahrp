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
        private readonly Context _context;
        private readonly ProdutoDAO _produtoDAO;
        private readonly PedidoDAO _pedidoDAO;
        private readonly AgenteDAO _agenteDAO;
        private readonly UserManager<AgenteLogado> _userManager;
        private readonly SignInManager<AgenteLogado> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PedidoController(Context context, ProdutoDAO produtoDAO, PedidoDAO pedidoDAO, AgenteDAO agenteDAO,
            UserManager<AgenteLogado> userManager, SignInManager<AgenteLogado> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _produtoDAO = produtoDAO;
            _pedidoDAO = pedidoDAO;
            _agenteDAO = agenteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = new SelectList(_produtoDAO.ListarTodos(), "ProdutoId", "NomeProduto");
            return View(Pedido_temp.GetPedido());
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            ViewBag.Produtos = new SelectList(_produtoDAO.ListarTodos(), "ProdutoId", "NomeProduto");
            if (Pedido_temp.GetListaItens().Count > 0)
            {
                if (ModelState.IsValid)
                {
                    pedido.ItensPedido = Pedido_temp.GetListaItens();
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
                        Pedido_temp.ClearData();
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            ModelState.AddModelError("", "Favor Adicionar no Mínimo 1 Produto!");
            return View(pedido);
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
                if (!Pedido_temp.AddItem(item)) {
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
            Pedido_temp.MaisQuantidade(nomeProduto);
            return RedirectToAction("Create");
        }

        public IActionResult DiminuirQntItemPedido(string nomeProduto)
        {
            Pedido_temp.MenosQuantidade(nomeProduto);
            return RedirectToAction("Create");
        }

        public IActionResult RemoveItemPedido(string nomeProduto)
        {
            Pedido_temp.RemoveItem(nomeProduto);
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
