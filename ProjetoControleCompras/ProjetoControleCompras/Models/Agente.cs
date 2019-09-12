using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    [Table("Agentes")]
    class Agente
    {
        public Agente()
        {
            DtCriacao = DateTime.Now;
        }

        [Key]
        public int IdAgente { get; set; }
        public string NomeAgente { get; set; }
        public Setor Setor { get; set; }
        public Cargo Cargo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
