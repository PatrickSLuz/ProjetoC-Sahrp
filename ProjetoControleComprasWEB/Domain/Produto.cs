using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Produtos")]
    public class Produto
    {
        public Produto()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
