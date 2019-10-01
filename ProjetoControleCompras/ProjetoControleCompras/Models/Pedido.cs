using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Pedidos")]
    class Pedido
    {
        public Pedido()
        {
            DtCriacao = DateTime.Now;
        }
        [Key]
        public int IdPedido { get; set; }
        public Agente Solicitante { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        public List<Orcamento> Orcamentos { get; set; }
        public string DescMot { get; set; }
        public Status Status { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
