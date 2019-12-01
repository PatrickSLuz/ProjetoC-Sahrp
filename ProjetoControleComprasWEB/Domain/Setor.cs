using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Setores")]
    public class Setor
    {
        public Setor()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int SetorId { get; set; }

        [Display(Name = "Nome Setor")]
        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        public string NomeSetor { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime DtCriacao { get; set; }
    }
}
