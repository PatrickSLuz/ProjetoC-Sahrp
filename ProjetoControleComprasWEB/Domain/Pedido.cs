using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Pedidos")]
    public class Pedido
    {
        public Pedido()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int PedidoId { get; set; }

        public Agente Solicitante { get; set; }

        public List<ItemPedido> ItensPedido { get; set; }

        public List<Orcamento> Orcamentos { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        public string DescMot { get; set; }

        public string Status { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime DtCriacao { get; set; }
    }
}
