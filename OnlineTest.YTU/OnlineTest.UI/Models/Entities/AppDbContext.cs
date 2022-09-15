using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTest.UI.Models.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ask> Asks { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}