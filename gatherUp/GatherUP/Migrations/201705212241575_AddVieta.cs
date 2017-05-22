namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVieta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vietas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pavadinimas = c.String(),
                        Adresas = c.String(),
                        Aprasymas = c.String(),
                        Bendras_ivertinimas = c.Double(nullable: false),
                        Istaigos_savininkasId = c.Int(nullable: false),
                        Istaigos_savininkas_Prisijungimo_vardas = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vartotojas", t => t.Istaigos_savininkas_Prisijungimo_vardas)
                .Index(t => t.Istaigos_savininkas_Prisijungimo_vardas);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vietas", "Istaigos_savininkas_Prisijungimo_vardas", "dbo.Vartotojas");
            DropIndex("dbo.Vietas", new[] { "Istaigos_savininkas_Prisijungimo_vardas" });
            DropTable("dbo.Vietas");
        }
    }
}
