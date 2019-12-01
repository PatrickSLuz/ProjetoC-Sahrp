using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Cargos")]
    public class Cargo
    {
        public Cargo()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int CargoId { get; set; }

        [Display(Name = "Nome Cargo")]
        [Required(ErrorMessage = "Campo Nome Obrigatório!")]
        public string NomeCargo { get; set; }

        [Display(Name = "Data Criação")]
        public DateTime DtCriacao { get; set; }
    }
}
