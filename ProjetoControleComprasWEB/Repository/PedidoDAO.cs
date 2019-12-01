using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PedidoDAO : IRepository<Pedido>
    {
        private readonly Context _context;

        public PedidoDAO(Context context)
        {
            _context = context;
        }

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante").
                FirstOrDefault(x => x.PedidoId == id);
        }

        public bool Cadastrar(Pedido objeto)
        {
            _context.Pedidos.Add(objeto);
            _context.SaveChanges();
            return true;
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.Include("ItemPedido").Include("Agente").ToList();
        }
    }
}
