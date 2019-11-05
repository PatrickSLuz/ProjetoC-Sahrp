using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Orcamentos")]
    public class Orcamento
    {
        public Orcamento()
        {
            DtCriacao = DateTime.Now;
        }
        [Key]
        public int OrcamentoId { get; set; }
        public Pedido Pedido { get; set; }
        public string NomeEmpresa { get; set; }
        public string CpfCnpjFornecedor { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
