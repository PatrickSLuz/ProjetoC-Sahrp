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

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Campo Razão Social Obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo CNPJ Obrigatório!")]
        public string Cnpj { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo Valor Obrigatório!")]
        [Range(1, 99999999, ErrorMessage = "Orçamento com o valor não aceito, Favor inserir valor valido!")]
        public double Valor { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Descrição Obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime DtCriacao { get; set; }
    }
}
