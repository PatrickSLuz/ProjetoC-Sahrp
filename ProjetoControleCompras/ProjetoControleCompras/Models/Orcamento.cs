using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Orcamentos")]
    class Orcamento
    {
        public Orcamento()
        {
            DtCriacao = DateTime.Now;
        }
        [Key]
        public int IdOrcamento { get; set; }
        public Pedido Pedido { get; set; }
        public string CpfCnpjFornecedor { get; set; }
        public double Valor { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
