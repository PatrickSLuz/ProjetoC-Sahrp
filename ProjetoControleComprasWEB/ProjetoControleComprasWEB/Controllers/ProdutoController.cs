using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository;
using System.Threading.Tasks;

namespace ProjetoControleComprasWEB.Controllers
{


    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;

       
        public IActionResult Edit(int id)
        {

            return View(_produtoDAO.BuscarPorId(id));
        }

        [HttpPost]    
        public IActionResult Edit(Produto produto)
        {
            if (_produtoDAO.Cadastrar(produto))
            {
                return RedirectToAction("Index");
            }
            return View(produto);
        }
        
        public IActionResult Remove(int? id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
