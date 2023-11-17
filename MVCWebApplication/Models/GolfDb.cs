using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class GolfDb: DbContext
    {

        public GolfDb() : base("name=DefaultConnection")
        {

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}