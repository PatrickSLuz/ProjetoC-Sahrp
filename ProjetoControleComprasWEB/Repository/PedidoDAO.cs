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
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante.Setor").
                FirstOrDefault(x => x.PedidoId == id);
        }

        public bool Cadastrar(Pedido objeto)
        {
            _context.Pedidos.Add(objeto);
            _context.SaveChanges();
            return true;
        }

        public bool AtualizarStatusPedido(int pedidoId, string status)
        {
            Pedido pedido = BuscarPorId(pedidoId);
            if (pedido != null)
            {
                pedido.Status = status;
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Orcamento> ListarOrcamentosPorPedido(int pedidoId)
        {

            Pedido pedido = BuscarPorId(pedidoId);
            return pedido.Orcamentos;
        }

        public List<ItemPedido> ListarItensPorPedidoId(int pedidoId)
        {
            Pedido pedido = BuscarPorId(pedidoId);
            return pedido.ItensPedido;
        }

        public List<Pedido> ListarPedidosPorSetor(int idSetor)
        {
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante.Setor").
                Where(x => x.Solicitante.Setor.SetorId.Equals(idSetor)).ToList();
        }

        public List<Pedido> ListarPedidosPorStatus(string status)
        {
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante.Setor").
                Where(x => x.Status.Equals(status)).ToList();
        }

        public List<Pedido> ListarPedidosPorSetorEStatusIgual(int idSetor, string status)
        {
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante.Setor").
                Where(x => x.Solicitante.Setor.SetorId.Equals(idSetor)).Where(x => x.Status.Equals(status)).ToList();
        }

        public List<Pedido> ListarPedidosPorSetorEStatusDiferente(int idSetor, string status)
        {
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante.Setor").
                Where(x => x.Solicitante.Setor.SetorId.Equals(idSetor)).Where(x => x.Status != status).ToList();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante.Setor").ToList();
        }
    }
}
