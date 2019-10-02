using ProjetoControleCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Utils
{
    class SetarSenhaPadrao
    {
        public static string CriarSenhaPadrao(Agente agente)
        {
            return char.ToUpper(agente.NomeAgente[0]) + "@" + agente.Cargo;
        }
    }
}
