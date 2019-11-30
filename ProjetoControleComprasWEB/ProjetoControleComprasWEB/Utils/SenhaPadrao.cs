using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoControleComprasWEB.Utils
{
    public class SenhaPadrao
    {
        public static string CriarSenhaPadrao(Agente agente)
        {
            return (char.ToUpper(agente.NomeAgente[0]).ToString()) + (char.ToLower(agente.NomeAgente[1]).ToString()) + "@" + agente.Cpf.Substring(0,5);
        }
    }
}
