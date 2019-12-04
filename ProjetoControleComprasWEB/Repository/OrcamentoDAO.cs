using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class OrcamentoDAO : IRepository<Orcamento>
    {
        private readonly Context _context;

        public OrcamentoDAO(Context context)
        {
            _context = context;
        }

        public Orcamento BuscarPorId(int id)
        {
            return _context.Orcamentos.Find(id);
        }

        public bool Cadastrar(Orcamento objeto)
        {
            _context.Orcamentos.Add(objeto);
            _context.SaveChanges();
            return true;
        }

        public List<Orcamento> ListarTodos()
        {
            return _context.Orcamentos.ToList();
        }

        public bool Delete(Orcamento objeto)
        {
            _context.Orcamentos.Remove(objeto);
            _context.SaveChanges();
            return true;
        }

        public bool Editar(Orcamento objeto)
        {
            _context.Orcamentos.Update(objeto);
            _context.SaveChanges();
            return true;
        }
    }
}
