using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TesteFramework.Models;

namespace TesteFramework.Core
{
    public class BancoDadosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public BancoDadosContext():
            base(nameOrConnectionString: "meuBancoDados")
        {
        }
    }
}