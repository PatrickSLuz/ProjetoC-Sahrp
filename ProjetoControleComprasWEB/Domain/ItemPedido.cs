using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("ItemPedido")]
    public class ItemPedido
    {
        public ItemPedido()
        {
            DtCriacao = DateTime.Now;
        }
        [Key]
        public int ItemPedidoId { get; set; }
        public Produto Produtos { get; set; }
        public int Quantidade { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
