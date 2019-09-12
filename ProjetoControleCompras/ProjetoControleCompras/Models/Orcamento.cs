using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Orcamento
    {
        public Orcamento()
        {
            DtCriacao = DateTime.Now;
        }

        public int IdOrcamento { get; set; }
        public Pedido Pedido { get; set; }
        public string CpfCnpjFornecedor { get; set; }
        public double Valor { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
