using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoControleCompras.Models;

namespace ProjetoControleCompras.DAL
{
    class OrcamentoDAO
    {
        private OrcamentoDAO() { }

        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarOrcamento(Orcamento orcamento)
        {
            ctx.Orcamentos.Add(orcamento);
            ctx.SaveChanges();
            return true;
        }

        public static List<Orcamento> ListarOrcamento() => ctx.Orcamentos.ToList();

        public static List<Orcamento> ListarOrcamentoPorPedido(int idPedido)
        {
            return ctx.Orcamentos.Include("Pedido").Where(x => x.Pedido.IdPedido == idPedido).ToList();
        }
    }
}
