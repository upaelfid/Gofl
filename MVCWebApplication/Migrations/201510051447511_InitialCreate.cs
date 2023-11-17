namespace MVCWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
              CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(maxLength: 4000),
                        h1lat = c.Double(nullable: false),    
                        h1ln  =c.Double(nullable: false),    
                        h2lat =c.Double(nullable: false),       
                        h2ln  =c.Double(nullable: false),
                        h3lat =c.Double(nullable: false),
                        h3ln  =c.Double(nullable: false),
                        h4lat =c.Double(nullable: false),
                        h4ln  =c.Double(nullable: false),
                        h5lat =c.Double(nullable: false),
                        h5ln  =c.Double(nullable: false),
                        h6lat =c.Double(nullable: false),
                        h6ln  =c.Double(nullable: false),
                        h7lat =c.Double(nullable: false),
                        h7ln  =c.Double(nullable: false),
                        h8lat =c.Double(nullable: false),
                        h8ln  =c.Double(nullable: false),
                        h9lat =c.Double(nullable: false),
                        h9ln  =c.Double(nullable: false),
                        h10lat=c.Double(nullable: false),
                        h10ln =c.Double(nullable: false),
                        h11lat=c.Double(nullable: false),
                        h11ln =c.Double(nullable: false),
                        h12lat=c.Double(nullable: false),
                        h12ln =c.Double(nullable: false),
                        h13lat=c.Double(nullable: false),
                        h13ln =c.Double(nullable: false),
                        h14lat=c.Double(nullable: false),
                        h14ln =c.Double(nullable: false),
                        h15lat=c.Double(nullable: false),
                        h15ln =c.Double(nullable: false),
                        h16lat=c.Double(nullable: false),
                        h16ln =c.Double(nullable: false),
                        h17lat=c.Double(nullable: false),
                        h17ln =c.Double(nullable: false),
                        h18lat=c.Double(nullable: false),
                        h18ln = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ccID = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CourseName = c.String(maxLength: 4000),
                        Team = c.String(maxLength: 4000),
                        gDate = c.DateTime(),
                        h1 = c.Int(nullable: false),
                        h2 = c.Int(nullable: false),
                        h3 = c.Int(nullable: false),
                        h4 = c.Int(nullable: false),
                        h5 = c.Int(nullable: false),
                        h6 = c.Int(nullable: false),
                        h7 = c.Int(nullable: false),
                        h8 = c.Int(nullable: false),
                        h9 = c.Int(nullable: false),
                        h10 = c.Int(nullable: false),
                        h11 = c.Int(nullable: false),
                        h12 = c.Int(nullable: false),
                        h13 = c.Int(nullable: false),
                        h14 = c.Int(nullable: false),
                        h15 = c.Int(nullable: false),
                        h16 = c.Int(nullable: false),
                        h17 = c.Int(nullable: false),
                        h18 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cards");
            DropTable("dbo.Courses");
        }
    }
}
