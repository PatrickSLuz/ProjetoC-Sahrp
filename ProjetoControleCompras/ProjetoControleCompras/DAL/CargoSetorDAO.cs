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

        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarSetor(Setor setor)
        {
            if (BuscarSetorPorNome(setor) == null)
            {
                ctx.Setores.Add(setor);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Setor BuscarSetorDoAgente(Agente agente)
        {
            return ctx.Setores.FirstOrDefault(x => x.IdSetor == agente.Setor.IdSetor);
        }

        public static Setor BuscarSetorPorNome(Setor setor)
        {
            return ctx.Setores.FirstOrDefault(x => x.NomeSetor.Equals(setor.NomeSetor));
        }

        public static Cargo BuscarCargoPorNome(Cargo cargo)
        {
            return ctx.Cargos.FirstOrDefault(x => x.NomeCargo.Equals(cargo.NomeCargo));
        }

        public static List<Cargo> ListarCargos() => ctx.Cargos.ToList();

        public static List<Setor> ListarSetores() => ctx.Setores.ToList();

        public static bool CadastrarCargo(Cargo cargo)
        {
            if (BuscarCargoPorNome(cargo) == null)
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
