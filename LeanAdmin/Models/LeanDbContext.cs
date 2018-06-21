using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeanAdmin.Models
{
    public class LeanDbContext : DbContext
    {
        public LeanDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Question> questions { get; set; }
        public DbSet<QuestionControl> questionControls { get; set; }
        public DbSet<QuestionAttribute> questionAttributes { get; set; }
    }
}