using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteFramework.Models
{
    [Table("tb_clientes")]
    public class Cliente
    {
        [Key]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("endereco")]
        public string Endereco { get; set; }

        [Required]
        [Column("telefone")]
        public string Telefone { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }
    }

    public class Countries
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }

    }

    [Table("tbl_States")]
    public class States
    {
        [Key]
        [Column("StateID")]
        public int StateID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("CountryID")]
        public int CountryID { get; set; }

    }

    [Table("tbl_Cities")]
    public class Citi
    {
        [Key]
        [Column("CityID")]
        public int CityID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("StateID")]
        public int StateID { get; set; }




    }

}