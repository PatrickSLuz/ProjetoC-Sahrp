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
            if (BuscarAgentePorID(agente.IdAgente) != null)
            {
                ctx.Entry(agente).CurrentValues.SetValues(agente);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                // Cadastrar Agente
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
        }

        public static Agente BuscarAgentePorLogin(Agente agente)
        {
            return ctx.Agentes.Include("Cargo").Include("Setor").FirstOrDefault(x => x.Login.Equals(agente.Login));
        }

        public static Agente BuscarAgentePorID(int id)
        {
            return ctx.Agentes.Find(id); // Buscar diretamente pela Chave Primaria (PK) da Table
        }

        public static void MudarSenha(Agente agente, string nova_senha)
        {
            agente.Senha = nova_senha;
            ctx.Entry(agente).CurrentValues.SetValues(agente);
            ctx.SaveChanges();
        }

        public static List<Agente> ListarAgentes() => ctx.Agentes.Include("Cargo").Include("Setor").ToList();

        public static List<Agente> ListarAgentesPorSetor(Agente agente)
        {
            return ctx.Agentes.Include("Cargo").Include("Setor").Where(x => x.Setor.IdSetor.Equals(agente.Setor.IdSetor)).ToList();
        }
    }
}
