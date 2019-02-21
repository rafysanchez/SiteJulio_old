using System;
using System.ComponentModel.DataAnnotations;

namespace area452.Models
{
   public  class Login
    {
        [Required(ErrorMessage = "Nome de usuario obrigatório.")]
        public String User { get; set; }
       
        //[ValidatePasswordLength]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        [Display(Name = "Senha")]
        public String Password { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "New password")]
        //public string NewPassword { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm new password")]
        //[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

    }
}
