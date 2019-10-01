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

        public static List<Pedido> BuscarPedidoPorAgente(Agente solicitante)
        {
            return ctx.Pedidos.Include("ItensPedido").Include("Status").
                Where(x => x.Solicitante.IdAgente.Equals(solicitante.IdAgente) && x.Status.IdStatus == 5 /*Pedido Finalizado*/).ToList();
        }

        public static List<Pedido> ListarPedidos()
        {
            return ctx.Pedidos.Include("Solicitante").Include("ItensPedido").Include("Status").ToList();
        }

        public static Status BuscarStatusPorId(int id)
        {
            return ctx.Status.Find(id);
        }
    }
}
