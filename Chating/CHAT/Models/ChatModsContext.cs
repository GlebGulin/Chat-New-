using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CHAT.Models
{
    public class ChatModsContext : DbContext
    {
        public DbSet<Chater> chaters { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<Messager> messagers { get; set; }
    }
}