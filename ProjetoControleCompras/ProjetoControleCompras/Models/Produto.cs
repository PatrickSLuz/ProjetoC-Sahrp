using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Produtos")]
    class Produto
    {
        public Produto()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
