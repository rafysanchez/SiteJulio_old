﻿using System.Data.Entity;
using TesteFramework.Models;

namespace TesteFramework.Core
{
    public class BancoDadosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Countries> countries { get; set; }
        public DbSet<States> states { get; set; }
        public DbSet<Citi> cities { get; set; }
        public DbSet<ClienteLoc> ClientesLoc { get; set; }
        public DbSet<Contato> contatos { get; set; }
        
        public BancoDadosContext():
            base(nameOrConnectionString: "MySQLConnection")
        {
        }
    }
}