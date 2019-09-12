using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Setores")]
    class Setor
    {
        public Setor()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
