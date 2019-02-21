using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace area452.Models
{
   
        [Table("tb_clientesLoc")]
        public class ClienteLoc
        {
          
            [Key]
            [Column("cliente_id")]
            public int ClienteId { get; set; }

            [Column("nome")]
            public string Nome { get; set; }

            [Column("endereco")]
            public string Endereco { get; set; }

            [Column("telefone")]
            public string Telefone { get; set; }

            [Column("email")]
            public string Email { get; set; }

            [Column("data_cadastro")]
            public DateTime data_cadastro { get; set; }

        }


}