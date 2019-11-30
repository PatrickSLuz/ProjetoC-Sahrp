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
            if (BuscarAgentePorEmail(objeto) == null)
            {
                _context.Agentes.Add(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public bool Editar(Agente objeto)
        {
            if (BuscarPorId(objeto.AgenteId) != null)
            {
                bool tracking = _context.ChangeTracker.Entries<Agente>().Any(x => x.Entity.AgenteId == objeto.AgenteId);
                if (!tracking)
                {
                    _context.Agentes.Update(objeto);
                }
                
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Deletar(Agente objeto)
        {
            _context.Agentes.Remove(objeto);
            _context.SaveChanges();
            return true;
        }

        public Agente BuscarPorId(int id)
        {
            return _context.Agentes.Find(id); // Buscar diretamente pela Chave Primaria (PK) da Table
        }

        public Agente BuscarAgentePorEmail(Agente agente)
        {
            return _context.Agentes.Include("Cargo").Include("Setor").FirstOrDefault(x => x.Email.Equals(agente.Email));
        }

        public List<Agente> ListarTodos()
        {
            return _context.Agentes.Include("Cargo").Include("Setor").ToList();
        }
    }
}
