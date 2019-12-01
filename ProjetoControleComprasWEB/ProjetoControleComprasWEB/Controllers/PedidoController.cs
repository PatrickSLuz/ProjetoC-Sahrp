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

namespace ProjetoControleComprasWEB.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Context _context;
        private readonly ProdutoDAO _produtoDAO;

        public PedidoController(Context context, ProdutoDAO produtoDAO)
        {
            _context = context;
            _produtoDAO = produtoDAO;
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
        public IActionResult Create(Pedido pedido, int drpProduto)
        {
            ViewBag.Produtos = new SelectList(_produtoDAO.ListarTodos(), "ProdutoId", "NomeProduto");
            if (ModelState.IsValid)
            {
                //return RedirectToAction(nameof(Index));
            }
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
                if (!TempPedido.AddItem(item)) {
                    ModelState.AddModelError("","Produto ja Adicionado!");
                }
            }
            return RedirectToAction("Create");
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
