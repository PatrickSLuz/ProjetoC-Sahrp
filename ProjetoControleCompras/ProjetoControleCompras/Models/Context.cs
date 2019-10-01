using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.Models
{
    class Context : DbContext
    {
        // Herdando o Contrutor da Classe Pai/DbContext e definindo o Nome do Banco de Dados
        public Context() : base("DbControleCompras") { }

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