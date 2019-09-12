using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Setor
    {
        public Setor()
        {
            DtCriacao = DateTime.Now;
        }

        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
