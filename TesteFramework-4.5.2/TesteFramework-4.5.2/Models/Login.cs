using System;
using System.ComponentModel.DataAnnotations;

namespace TesteFramework.Models
{
   public  class Login
    {
        [Required(ErrorMessage = "Nome de usuario obrigatório.")]
        public String User { get; set; }


        
        //[ValidatePasswordLength]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        public String Password { get; set; }

    }
}
