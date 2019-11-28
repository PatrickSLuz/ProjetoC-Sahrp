using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    class ProdutoDAO : IRepository<Produto>
    {
        private readonly Context _context;

        public ProdutoDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Produto objeto)
        {
            if(BuscarPorId(objeto.ProdutoId)!=null)
            {
                _context.Entry(objeto).CurrentValues.SetValues(objeto);
                _context.SaveChanges();
                return true;
            }
            else
            {
                if(BuscarProdutoPorNome(objeto)!=null)
                {
                    _context.Produtos.Add(objeto);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Produto BuscarProdutoPorNome(Produto produto)
        {
            return _context.Produtos.FirstOrDefault(x => x.NomeProduto.Equals(produto.NomeProduto));
        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.Find(id);
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }

 
    }
}
