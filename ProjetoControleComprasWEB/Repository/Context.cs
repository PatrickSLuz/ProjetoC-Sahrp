using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Context : DbContext
    {
        // Herdando o Contrutor da Classe Pai/DbContext
        public Context(DbContextOptions<Context> options) : base(options) { }

        // Definir as Classes que irão se tornar tabelas no BD
    }
}
