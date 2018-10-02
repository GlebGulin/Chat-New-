using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAT.ViewModels
{
    public class ChaterViewModel
    {
        [Required, MinLength(2)]
        [Display(Name = "Введите имя")]
        public string ChaterkName { get; set; }
        [Required, MinLength(5), DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Pass { get; set; }

        [Compare("Pass"), DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPass { get; set; }
        [EmailAddress, Required]
        [Display(Name = "Введите свой электронный адресс")]
        public string Email { get; set; }
        
    }
}