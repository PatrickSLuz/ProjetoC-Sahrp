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
    }
}
