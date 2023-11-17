namespace MVCWebApplication.Migrations
{
    using MVCWebApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCWebApplication.Models.GolfDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCWebApplication.Models.GolfDb";
        }

        protected override void Seed(MVCWebApplication.Models.GolfDb context)
        {
            context.Cards.AddOrUpdate(r => r.Name,
                           new Card { Name = "Phillip", CourseName = "Link1", Team = "Lava", ccID = 602, gDate = DateTime.Parse("1/1/1900 12:00:00 AM"), h1 = 7, h2 = 4, h3 = 6, h4 = 9, h5 = 3, h6 = 4, h7 = 3, h8 = 4, h9 = 3, h10 = 3, h11 = 7, h12 = 4, h13 = 6, h14 = 9, h15 = 3, h16 = 4, h17 = 3, h18 = 4 },
                           new Card { Name = "Maria", CourseName = "Link1", Team = "Lava", ccID = 602, gDate = DateTime.Parse("1/1/1900 12:00:00 AM"), h1 = 7, h2 = 1, h3 = 6, h4 = 1, h5 = 3, h6 = 4, h7 = 3, h8 = 4, h9 = 1, h10 = 3, h11 = 7, h12 = 4, h13 = 6, h14 = 1, h15 = 3, h16 = 4, h17 = 3, h18 = 4 });
            context.Courses.AddOrUpdate(r => r.CourseName,
                new Course { CourseName = "Shaker Country Club",
                    h1lat = 42.086690, h1ln = -72.736543,
                    h2lat = 42.084277, h2ln = -72.736487,
                    h3lat = 42.086339, h3ln = -72.734774,
                    h4lat = 42.089608, h4ln = -72.736739,
                    h5lat = 42.089782, h5ln = -72.733589,
                    h6lat = 42.090598, h6ln = -72.738246,
                    h7lat = 42.087984, h7ln = -72.736262,
                    h8lat = 42.089717, h8ln = -72.739313,
                    h9lat = 42.088873, h9ln = -72.741144,
                    h10lat = 42.086046, h10ln = -72.741703,
                    h11lat = 42.086246, h11ln = -72.737244,
                    h12lat = 42.084517, h12ln = -72.737273,
                    h13lat = 42.085624, h13ln = -72.739970,
                    h14lat = 42.085129, h14ln = -72.740026,
                    h15lat = 42.086169, h15ln = -72.743163,
                    h16lat = 42.083246, h16ln = -72.744825,
                    h17lat = 42.086812, h17ln = -72.743432,
                    h18lat = 42.088564, h18ln = -72.742586,
                }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
