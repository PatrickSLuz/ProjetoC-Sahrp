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

            // procura por qualquer Setor Cadastrado
            if (context.Setores.Any())
            {
                return;  //O banco foi inicializado
            }
            var setores = new Setor[]
            {
            new Setor{NomeSetor="Diretoria"},
            new Setor{NomeSetor="Financeiro"},
            new Setor{NomeSetor="Compras"}
            };
            foreach (Setor s in setores)
            {
                context.Setores.Add(s);
            }
            context.SaveChanges();

            // procura por qualquer Cargo Cadastrado
            if (context.Cargos.Any())
            {
                return;  //O banco foi inicializado
            }
            var cargos = new Cargo[]
            {
            new Cargo{NomeCargo="Administrador"},
            new Cargo{NomeCargo="Gestor"},
            new Cargo{NomeCargo="Usuario"}
            };
            foreach (Cargo c in cargos)
            {
                context.Cargos.Add(c);
            }
            context.SaveChanges();


            // procura por qualquer Agente Cadastrado
            if (context.Agentes.Any())
            {
                return;  //O banco foi inicializado
            }
            var cargo = context.Cargos.FirstOrDefault(x => x.NomeCargo.Equals("Administrador"));
            var setor = context.Setores.FirstOrDefault(x => x.NomeSetor.Equals("Diretoria"));
            var agentes = new Agente[]
            {
            new Agente{NomeAgente="Administrador", Cargo=cargo, Setor=setor, Email="admin@email.com", Senha="admin"}
            };
            foreach (Agente a in agentes)
            {
                context.Agentes.Add(a);
            }
            context.SaveChanges();
        }
    }
}
