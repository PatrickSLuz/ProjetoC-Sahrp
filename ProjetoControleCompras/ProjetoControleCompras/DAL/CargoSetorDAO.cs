using ProjetoControleCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleCompras.DAL
{
    class CargoSetorDAO
    {
        private CargoSetorDAO() { }

        public static void CadastrarSetor(Setor setor)
        {
            Console.WriteLine("CargoSetorDAO.CadastrarSetor(Setor setor) - NomeSetor: " + setor.NomeSetor);
        }

        public static void CadastrarCargo(Cargo cargo)
        {
            Console.WriteLine("CargoSetorDAO.CadastrarCargo(Cargo cargo) - NomeCargo: " + cargo.NomeCargo);
        }
    }
}
