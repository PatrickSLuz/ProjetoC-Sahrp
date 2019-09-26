using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class ItemPedido
    {
        public ItemPedido()
        {
            DtCriacao = DateTime.Now;
        }

        public int IdItemPedido { get; set; }
        public Produto Produtos { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
