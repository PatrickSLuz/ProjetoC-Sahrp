using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Agente
    {
        public Agente()
        {
            DtCriacao = DateTime.Now;
        }

        public int IdAgente { get; set; }
        public string NomeAgente { get; set; }
        public Setor Setor { get; set; }
        public Cargo Cargo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
