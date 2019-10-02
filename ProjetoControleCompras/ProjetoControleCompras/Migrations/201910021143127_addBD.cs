namespace ProjetoControleCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agentes",
                c => new
                    {
                        IdAgente = c.Int(nullable: false, identity: true),
                        NomeAgente = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        DtCriacao = c.DateTime(nullable: false),
                        Cargo_IdCargo = c.Int(),
                        Setor_IdSetor = c.Int(),
                    })
                .PrimaryKey(t => t.IdAgente)
                .ForeignKey("dbo.Cargos", t => t.Cargo_IdCargo)
                .ForeignKey("dbo.Setores", t => t.Setor_IdSetor)
                .Index(t => t.Cargo_IdCargo)
                .Index(t => t.Setor_IdSetor);
            
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        IdCargo = c.Int(nullable: false, identity: true),
                        NomeCargo = c.String(),
                        DtCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCargo);
            
            CreateTable(
                "dbo.Setores",
                c => new
                    {
                        IdSetor = c.Int(nullable: false, identity: true),
                        NomeSetor = c.String(),
                        DtCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdSetor);
            
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        IdItemPedido = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        DtCriacao = c.DateTime(nullable: false),
                        Produtos_IdProduto = c.Int(),
                        Pedido_IdPedido = c.Int(),
                    })
                .PrimaryKey(t => t.IdItemPedido)
                .ForeignKey("dbo.Produtos", t => t.Produtos_IdProduto)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_IdPedido)
                .Index(t => t.Produtos_IdProduto)
                .Index(t => t.Pedido_IdPedido);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(),
                        DtCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduto);
            
            CreateTable(
                "dbo.Orcamentos",
                c => new
                    {
                        IdOrcamento = c.Int(nullable: false, identity: true),
                        CpfCnpjFornecedor = c.String(),
                        Valor = c.Double(nullable: false),
                        DtCriacao = c.DateTime(nullable: false),
                        Pedido_IdPedido = c.Int(),
                    })
                .PrimaryKey(t => t.IdOrcamento)
                .ForeignKey("dbo.Pedidos", t => t.Pedido_IdPedido)
                .Index(t => t.Pedido_IdPedido);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        DescMot = c.String(),
                        Status = c.String(),
                        DtCriacao = c.DateTime(nullable: false),
                        Solicitante_IdAgente = c.Int(),
                    })
                .PrimaryKey(t => t.IdPedido)
                .ForeignKey("dbo.Agentes", t => t.Solicitante_IdAgente)
                .Index(t => t.Solicitante_IdAgente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "Solicitante_IdAgente", "dbo.Agentes");
            DropForeignKey("dbo.Orcamentos", "Pedido_IdPedido", "dbo.Pedidos");
            DropForeignKey("dbo.ItemPedido", "Pedido_IdPedido", "dbo.Pedidos");
            DropForeignKey("dbo.ItemPedido", "Produtos_IdProduto", "dbo.Produtos");
            DropForeignKey("dbo.Agentes", "Setor_IdSetor", "dbo.Setores");
            DropForeignKey("dbo.Agentes", "Cargo_IdCargo", "dbo.Cargos");
            DropIndex("dbo.Pedidos", new[] { "Solicitante_IdAgente" });
            DropIndex("dbo.Orcamentos", new[] { "Pedido_IdPedido" });
            DropIndex("dbo.ItemPedido", new[] { "Pedido_IdPedido" });
            DropIndex("dbo.ItemPedido", new[] { "Produtos_IdProduto" });
            DropIndex("dbo.Agentes", new[] { "Setor_IdSetor" });
            DropIndex("dbo.Agentes", new[] { "Cargo_IdCargo" });
            DropTable("dbo.Pedidos");
            DropTable("dbo.Orcamentos");
            DropTable("dbo.Produtos");
            DropTable("dbo.ItemPedido");
            DropTable("dbo.Setores");
            DropTable("dbo.Cargos");
            DropTable("dbo.Agentes");
        }
    }
}
