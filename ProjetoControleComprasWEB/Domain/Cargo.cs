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
        public string NomeCargo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
