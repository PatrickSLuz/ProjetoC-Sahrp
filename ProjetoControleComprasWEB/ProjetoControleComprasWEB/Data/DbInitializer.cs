using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoControleComprasWEB.Data
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            // procura por qualquer Agente Cadastrado
            if (context.Agentes.Any())
            {
                return;  //O banco foi inicializado
            }

            var agentes = new Agente[]
            {
            new Agente{NomeAgente="Administrador", Login="admin", Senha="admin"}
            };
            foreach (Agente a in agentes)
            {
                context.Agentes.Add(a);
            }
            context.SaveChanges();
        }
    }
}
