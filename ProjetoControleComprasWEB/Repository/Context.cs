using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Context : DbContext
    {
        // Herdando o Contrutor da Classe Pai/DbContext
        public Context(DbContextOptions<Context> options) : base(options) { }

        // Definir as Classes que irão se tornar tabelas no BD
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
    }
}
