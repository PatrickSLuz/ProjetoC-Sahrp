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

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        public string NomeProduto { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime DtCriacao { get; set; }
    }
}
