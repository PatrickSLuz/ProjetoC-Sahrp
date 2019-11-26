using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoControleComprasWEB.Controllers
{
    public class ProdutoController : Controller
    {
        public bool CadastrarProduto(Produto produto)
        {
            //Editar o que ja esta cadastrado
            if (BuscarProdutoPorNome(produto.ProdutoId) == null)
            {
               return _Context
            }
        }

        public BuscarProdutoPorID(int id)
        {
            return 
        }

        public Produto BuscarProdutoPorNome(Produto produto)
        {
            return 
        }
        public static List<Produto> ListarProdutos()
        {

        }
            {
                
            }
    }
}
