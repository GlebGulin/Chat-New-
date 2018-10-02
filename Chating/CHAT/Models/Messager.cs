using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CHAT.Models
{
    public class Messager
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
       // [ScaffoldColumn(false)]
        public DateTime? Published { get; set; }
        
        public int ChaterId { get; set; }
        [ForeignKey("ChaterId")]
        public virtual Chater Chater { get; set; }
        //потом возможно убрать!!!!!!!
        public ICollection<Answer> Answers { get; set; }
    }
}