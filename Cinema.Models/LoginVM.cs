using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Models
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
