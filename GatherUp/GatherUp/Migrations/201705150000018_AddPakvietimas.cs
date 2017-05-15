namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPakvietimas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pakvietimas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zinute = c.String(unicode: false),
                        Busena = c.Int(nullable: false),
                        SiuntejoId = c.Int(),
                        Vartotojas_Prisijungimo_vardas = c.String(maxLength: 128, storeType: "nvarchar"),
                        Rezervacija_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vartotojas", t => t.Vartotojas_Prisijungimo_vardas)
                .ForeignKey("dbo.Rezervacija", t => t.Rezervacija_Id)
                .Index(t => t.Vartotojas_Prisijungimo_vardas)
                .Index(t => t.Rezervacija_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pakvietimas", "Rezervacija_Id", "dbo.Rezervacija");
            DropForeignKey("dbo.Pakvietimas", "Vartotojas_Prisijungimo_vardas", "dbo.Vartotojas");
            DropIndex("dbo.Pakvietimas", new[] { "Rezervacija_Id" });
            DropIndex("dbo.Pakvietimas", new[] { "Vartotojas_Prisijungimo_vardas" });
            DropTable("dbo.Pakvietimas");
        }
    }
}
