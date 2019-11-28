using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SetorDAO : IRepository<Setor>
    {
        private readonly Context _context;

        public SetorDAO(Context context)
        {
            _context = context;
        }
        public Setor BuscarPorId(int id)
        {
            return _context.Setores.Find(id);
        }

        public bool Cadastrar(Setor objeto)
        {
            if (BuscarSetorPorNome(objeto) == null)
            {
                _context.Setores.Add(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Setor BuscarSetorPorNome(Setor setor)
        {
            return _context.Setores.FirstOrDefault(x => x.NomeSetor.Equals(setor.NomeSetor));
        }

        public List<Setor> ListarTodos()
        {
            return _context.Setores.ToList();
        }
    }
}
