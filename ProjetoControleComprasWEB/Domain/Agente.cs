using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Agentes")]
    public class Agente
    {
        public Agente()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int AgenteId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        public string NomeAgente { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo CPF Obrigatório!")]
        public string Cpf { get; set; }

        //[Required(ErrorMessage = "Campo Setor Obrigatório!")]
        public Setor Setor { get; set; }

        //[Required(ErrorMessage = "Campo Cargo Obrigatório!")]
        public Cargo Cargo { get; set; }

        [Required(ErrorMessage = "Campo Email Obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime DtCriacao { get; set; }
    }
}
