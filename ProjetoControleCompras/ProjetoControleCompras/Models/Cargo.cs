using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Cargo
    {
        public Cargo()
        {
            DtCriacao = DateTime.Now;
        }

        public int IdCargo { get; set; }
        public string NomeCargo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
