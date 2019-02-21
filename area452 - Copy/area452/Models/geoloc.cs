using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace area452.Models
{
    [Table("geoloc")]
    public class geoloc
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("PlaceName")]
        public string PlaceName { get; set; }
        [Column("OpeningHours")]
        public string OpeningHours { get; set; }
        [Column("GeoLong")]
        public string GeoLong { get; set; }
        [Column("GeoLat")]
        public string GeoLat { get; set; }

    }

    public class BaseEntidade : DbContext
    {
        public BaseEntidade()
            : base("name=MySQLConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public DbSet<geoloc> Geoloc { get; set; }
        

    }

}