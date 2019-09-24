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
            if (BuscarAgentePorLogin(agente) == null)
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

        public static Agente BuscarAgentePorLogin(Agente agente)
        {
            return ctx.Agentes.Include("Cargo").Include("Setor").FirstOrDefault(x => x.Login.Equals(agente.Login));
        }

        public static void MudarSenha(Agente agente, string nova_senha)
        {
            agente.Senha = nova_senha;
            ctx.Entry(agente).CurrentValues.SetValues(agente);
           //agente = ctx.Agentes.Find(agente.IdAgente);
           ctx.SaveChanges();
        }

    }
}
