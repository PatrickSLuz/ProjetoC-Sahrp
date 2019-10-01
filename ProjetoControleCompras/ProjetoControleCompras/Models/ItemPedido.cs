using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("ItemPedido")]
    class ItemPedido
    {
        public ItemPedido()
        {
            DtCriacao = DateTime.Now;
        }
        [Key]
        public int IdItemPedido { get; set; }
        public Produto Produtos { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
