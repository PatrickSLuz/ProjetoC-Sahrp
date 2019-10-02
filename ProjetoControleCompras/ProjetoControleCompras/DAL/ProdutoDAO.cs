using ProjetoControleCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.DAL
{
    class ProdutoDAO
    {
        private ProdutoDAO() { }

        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarProduto(Produto produto)
        {
            // Editar Produto
            if (BuscarProdutoPorID(produto.IdProduto) != null)
            {
                ctx.Entry(produto).CurrentValues.SetValues(produto);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                // Cadastrar Produto
                if (BuscarProdutoPorNome(produto) == null)
                {
                    ctx.Produtos.Add(produto);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool ExcluirProduto(Produto produto)
        {
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();
            return true;
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return ctx.Produtos.FirstOrDefault(x => x.NomeProduto.Equals(produto.NomeProduto));
        }

        public static Produto BuscarProdutoPorID(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public static List<Produto> ListarProdutos() => ctx.Produtos.ToList();
    }
}
