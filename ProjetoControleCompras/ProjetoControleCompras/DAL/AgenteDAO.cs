using ProjetoControleCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.DAL
{
    class AgenteDAO
    {
        private AgenteDAO() { }

        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarAgente(Agente agente)
        {
            if (BuscarAgentePorNome(agente) == null)
            {
                ctx.Agentes.Add(agente);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Agente BuscarAgentePorNome(Agente agente)
        {
            return ctx.Agentes.FirstOrDefault(x => x.Login.Equals(agente.Login));
        }
    }
}
