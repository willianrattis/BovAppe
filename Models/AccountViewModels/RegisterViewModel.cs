using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPP.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ser pelo menos {2} e no máximo {1} caracteres de tamanho.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha e senha de confirmação não se correspondem.")]
        public string ConfirmPassword { get; set; }
    }
}
