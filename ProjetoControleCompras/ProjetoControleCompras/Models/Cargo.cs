using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Cargos")]
    class Cargo
    {
        public Cargo()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int IdCargo { get; set; }
        public string NomeCargo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
