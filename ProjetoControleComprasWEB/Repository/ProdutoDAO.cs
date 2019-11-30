using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ProdutoDAO : IRepository<Produto>
    {
        private readonly Context _context;

        public ProdutoDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Produto objeto)
        {
            if (BuscarProdutoPorNome(objeto) == null)
            {
                _context.Produtos.Add(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Editar(Produto objeto)
        {
            if (BuscarProdutoPorNome(objeto) == null)
            {
                _context.Produtos.Update(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Deletar(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return true;
        }

        public Produto BuscarProdutoPorNome(Produto produto)
        {
            return _context.Produtos.FirstOrDefault(x => x.NomeProduto.Equals(produto.NomeProduto));
        }

        public void Remove(int id)
        {
            _context.Produtos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
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
