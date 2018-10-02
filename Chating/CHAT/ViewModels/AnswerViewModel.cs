using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAT.ViewModels
{
    public class AnswerViewModel
    {
        public string Message { get; set; }
        public int MessId { get; set; }
    }
}