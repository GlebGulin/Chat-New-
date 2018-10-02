using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CHAT.Models
{
    public class Chater
    {
        [Key]
        public int Id { get; set; }
        //[Required, MinLength(5), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        //[Required, MinLength(5), Index(IsUnique = true), StringLength(40)]
        [Required, MinLength(2)]
        [Display(Name ="Имя")]
        public string ChaterkName { get; set; }
        [Required,MinLength(5),DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Pass { get; set; }
        //public string Message { get; set; }
        [EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR")]
        [Display(Name = "Почтовый адресс")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Аватар)")]
        public string ImageLink { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Акаунт создан:")]
        public DateTime? DateRegistered { get; set; }
        //public DateTime DateRegister { get; set; }
        //public Chater()
        //{
        //    DateRegister = DateTime.Now;
        //}
    }
}