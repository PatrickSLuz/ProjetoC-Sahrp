using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CargoDAO : IRepository<Cargo>
    {
        private readonly Context _context;

        public CargoDAO(Context context)
        {
            _context = context;
        }
        public Cargo BuscarPorId(int id)
        {
            return _context.Cargos.Find(id);
        }

        public bool Cadastrar(Cargo objeto)
        {
            if (BuscarCargoPorNome(objeto) == null)
            {
                _context.Cargos.Add(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Cargo BuscarCargoPorNome(Cargo cargo)
        {
            return _context.Cargos.FirstOrDefault(x => x.NomeCargo.Equals(cargo.NomeCargo));
        }

        public List<Cargo> ListarTodos()
        {
            return _context.Cargos.ToList();
        }
    }
}
