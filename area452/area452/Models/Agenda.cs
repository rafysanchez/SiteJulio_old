using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace area452.Models
{
    public class Agenda
    {

        [Display(Name = "Id")]
        public int AgendaID { get; set; }

        [Required(ErrorMessage = "casa is required.")]
        public string Casa { get; set; }

        [Required(ErrorMessage = "cliente is required.")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "data de entrada necessária.")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "data de saída necessária.")]
        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "hora de entrada necessária.")]
        public DateTime HoraEntrada { get; set; }

        [Required(ErrorMessage = "hora de esntrada necessária.")]
        public DateTime HoraSaida { get; set; }

        [Required(ErrorMessage = "telefone is required.")]
        public string Telefone { get; set; }
    }


    public partial class tbl1
    {
        public int id { get; set; }
        public string Nome { get; set; }
    }



    public class AgendaEntities : DbContext
    {
        public AgendaEntities()
            : base("name=MySQLConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Agenda> agenda { get; set; }
        public DbSet<tbl1> tbl1 { get; set; }
        public DbSet<ClienteLoc> ClienteLoc { get; set; }
        public DbSet<Login> login { get; set; }
        
    }
}