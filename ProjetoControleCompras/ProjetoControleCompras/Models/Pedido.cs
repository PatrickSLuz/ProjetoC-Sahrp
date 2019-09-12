using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Pedido
    {
        public Pedido()
        {
            DtCriacao = DateTime.Now;
        }

        public int IdPedido { get; set; }
        public Agente Solicitante { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        public List<Orcamento> Orcamentos { get; set; }
        public string Status { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
