using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAT.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        public HttpPostedFileWrapper Photo { get; set; }
    }
}