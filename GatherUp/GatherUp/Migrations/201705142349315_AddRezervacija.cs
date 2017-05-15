namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRezervacija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rezervacija",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Busena = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Zinute = c.String(unicode: false),
                        Vartotojas_Prisijungimo_vardas = c.String(maxLength: 128, storeType: "nvarchar"),
                        Vieta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vartotojas", t => t.Vartotojas_Prisijungimo_vardas)
                .ForeignKey("dbo.Vieta", t => t.Vieta_Id)
                .Index(t => t.Vartotojas_Prisijungimo_vardas)
                .Index(t => t.Vieta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezervacija", "Vieta_Id", "dbo.Vieta");
            DropForeignKey("dbo.Rezervacija", "Vartotojas_Prisijungimo_vardas", "dbo.Vartotojas");
            DropIndex("dbo.Rezervacija", new[] { "Vieta_Id" });
            DropIndex("dbo.Rezervacija", new[] { "Vartotojas_Prisijungimo_vardas" });
            DropTable("dbo.Rezervacija");
        }
    }
}
