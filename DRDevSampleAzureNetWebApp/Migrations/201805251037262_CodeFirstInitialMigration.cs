namespace DRDevSampleAzureNetWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanetDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AstronomicalSymbol = c.String(),
                        DistanceToSun = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EquatorialRadius = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EquatorialGravity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanetDetails");
        }
    }
}
