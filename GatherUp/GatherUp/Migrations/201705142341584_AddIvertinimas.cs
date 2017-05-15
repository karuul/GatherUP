namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIvertinimas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ivertinimas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ivertinimo_balas = c.Int(nullable: false),
                        Komentaras = c.String(unicode: false),
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
            DropForeignKey("dbo.Ivertinimas", "Vieta_Id", "dbo.Vieta");
            DropForeignKey("dbo.Ivertinimas", "Vartotojas_Prisijungimo_vardas", "dbo.Vartotojas");
            DropIndex("dbo.Ivertinimas", new[] { "Vieta_Id" });
            DropIndex("dbo.Ivertinimas", new[] { "Vartotojas_Prisijungimo_vardas" });
            DropTable("dbo.Ivertinimas");
        }
    }
}
