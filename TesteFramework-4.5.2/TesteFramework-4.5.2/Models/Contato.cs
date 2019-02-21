using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteFramework.Models
{

    [Table("tbl_Contato")]
    public class Contato
    {
        [Key]
        [Column("ContatoID")]
        public int ContatoID { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Site")]
        public string Site { get; set; }
        [Column("Comentario")]
        public string Comentario { get; set; }

    }
}