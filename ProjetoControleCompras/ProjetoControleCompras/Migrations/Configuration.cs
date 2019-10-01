namespace ProjetoControleCompras.Migrations
{
    using ProjetoControleCompras.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoControleCompras.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjetoControleCompras.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<Cargo> listaCargos = new List<Cargo>();
            listaCargos.Add(new Cargo() { NomeCargo = "Usuario" });
            listaCargos.Add(new Cargo() { NomeCargo = "Gestor" });
            listaCargos.Add(new Cargo() { NomeCargo = "Administrador" });
            foreach (Cargo c in listaCargos)
            {
                context.Cargos.AddOrUpdate(x => x.IdCargo, c);
            }
            context.SaveChanges();

            List<Setor> listaSetores = new List<Setor>();
            listaSetores.Add(new Setor() { NomeSetor = "Financeiro" });
            listaSetores.Add(new Setor() { NomeSetor = "Compras" });
            listaSetores.Add(new Setor() { NomeSetor = "Diretoria" });
            foreach (Setor s in listaSetores)
            {
                context.Setores.AddOrUpdate(x => x.IdSetor, s);
            }
            context.SaveChanges();

            var cargo = context.Cargos.FirstOrDefault(c => c.NomeCargo.Equals("Administrador"));
            var setor = context.Setores.FirstOrDefault(c => c.NomeSetor.Equals("Diretoria"));
            context.Agentes.AddOrUpdate(new Agente() { NomeAgente = "Administrador", Cargo = cargo, Setor = setor, Login = "admin", Senha = "admin" });
            context.SaveChanges();

            List<Status> listaStatus = new List<Status>();
            listaStatus.Add(new Status() { NomeStatus = "Aguardando Validação do Gestor." });
            listaStatus.Add(new Status() { NomeStatus = "Aguardando Cadastro de Orçamentos." });
            listaStatus.Add(new Status() { NomeStatus = "Aguardando Compra do Pedido." });
            listaStatus.Add(new Status() { NomeStatus = "Pedido Cancelado." });
            listaStatus.Add(new Status() { NomeStatus = "Pedido Finalizado." });
            foreach (Status st in listaStatus);
        }
    }
}
