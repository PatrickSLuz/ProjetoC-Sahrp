using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AgenteDAO : IRepository<Agente>
    {
        private readonly Context _context;

        public AgenteDAO(Context contex)
        {
            _context = contex;
        }

        public bool Cadastrar(Agente objeto)
        {
            throw new NotImplementedException();
        }

        public Agente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Agente BuscarAgentePorLogin(Agente agente)
        {
            return _context.Agentes.Include("Cargo").Include("Setor").FirstOrDefault(x => x.Login.Equals(agente.Login));
        }

        public List<Agente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
