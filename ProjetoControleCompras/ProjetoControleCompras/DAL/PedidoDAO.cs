using ProjetoControleCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.DAL
{
    class PedidoDAO
    {
        private PedidoDAO() { }

        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarPedido(Pedido pedido)
        {
            ctx.Pedidos.Add(pedido);
            ctx.SaveChanges();
            return true;
        }

        public static bool AtualizarStatusPedido(Pedido pedido)
        {
            Pedido p = ctx.Pedidos.Find(pedido.IdPedido);
            if (p != null)
            {
                ctx.Entry(p).CurrentValues.SetValues(pedido);
                ctx.SaveChanges();
                return true;
            }
            else
                return false;
            
        }

        public static Pedido BuscarPedidoPorID(int id)
        {
            return ctx.Pedidos.Include("ItensPedido.Produtos").Include("Orcamentos").Include("Solicitante").FirstOrDefault(x => x.IdPedido == id);
        }

        public static List<Pedido> BuscarPedidoPorAgenteEStatus(Agente solicitante, string status)
        {
            return ctx.Pedidos.Include("ItensPedido.Produtos").
                Where(x => x.Solicitante.IdAgente.Equals(solicitante.IdAgente) && x.Status.Equals(status)).ToList();
        }

        public static Pedido BuscarPedidoPorAgente(Agente solicitante)
        {
            return ctx.Pedidos.Include("ItensPedido.Produtos").FirstOrDefault(x => x.Solicitante.IdAgente.Equals(solicitante.IdAgente));
        }

        public static List<Pedido> ListarPedidoPorAgente(Agente solicitante)
        {
            return ctx.Pedidos.Include("ItensPedido.Produtos").Where(x => x.Solicitante.IdAgente.Equals(solicitante.IdAgente)).ToList();
        }

        public static List<Pedido> ListarPedidos()
        {
            return ctx.Pedidos.Include("Solicitante.Cargo").Include("Solicitante.Setor").Include("ItensPedido.Produtos").ToList();
        }

        public static List<Pedido> ListarPedidosPorStatus(string status)
        {
            return ctx.Pedidos.Include("Solicitante.Cargo").Include("Solicitante.Setor").Include("ItensPedido.Produtos").
                Where(x => x.Status.Equals(status)).ToList();
        }

        public static List<Pedido> ListarPedidosPorSetor(int idSetor)
        {
            return ctx.Pedidos.Include("Solicitante.Cargo").Include("Solicitante.Setor").Include("ItensPedido.Produtos").
                Where(x => x.Solicitante.Setor.IdSetor.Equals(idSetor)).ToList();
        }

        public static List<Pedido> ListarPedidosPorSetorEStatusIgual(int idSetor, string status)
        {
            return ctx.Pedidos.Include("Solicitante.Cargo").Include("Solicitante.Setor").Include("ItensPedido").
                Where(x => x.Solicitante.Setor.IdSetor.Equals(idSetor)).Where(x => x.Status.Equals(status)).ToList();
        }
    }
}
