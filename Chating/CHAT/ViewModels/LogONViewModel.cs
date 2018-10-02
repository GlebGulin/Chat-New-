using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAT.ViewModels
{
    public class LogONViewModel
    {
        [Required, MinLength(2)]
        [Display(Name = "Введите имя")]
        public string ChaterkName { get; set; }
        [Required, MinLength(5), DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Pass { get; set; }
       // public HttpPostedFileWrapper Photo { get; set; }
    }
}