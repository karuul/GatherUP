namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecenzija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recenzija",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ivertinimo_balas = c.Int(nullable: false),
                        Tekstas = c.String(unicode: false),
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
            DropForeignKey("dbo.Recenzija", "Vieta_Id", "dbo.Vieta");
            DropForeignKey("dbo.Recenzija", "Vartotojas_Prisijungimo_vardas", "dbo.Vartotojas");
            DropIndex("dbo.Recenzija", new[] { "Vieta_Id" });
            DropIndex("dbo.Recenzija", new[] { "Vartotojas_Prisijungimo_vardas" });
            DropTable("dbo.Recenzija");
        }
    }
}
