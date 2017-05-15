namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVieta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vieta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresas = c.String(unicode: false),
                        Aprasymas = c.String(unicode: false),
                        Bendras_ivertinimas = c.Double(nullable: false),
                        Istaigos_savininkasId = c.Int(nullable: false),
                        Istaigos_savininkas_Prisijungimo_vardas = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vartotojas", t => t.Istaigos_savininkas_Prisijungimo_vardas)
                .Index(t => t.Istaigos_savininkas_Prisijungimo_vardas);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vieta", "Istaigos_savininkas_Prisijungimo_vardas", "dbo.Vartotojas");
            DropIndex("dbo.Vieta", new[] { "Istaigos_savininkas_Prisijungimo_vardas" });
            DropTable("dbo.Vieta");
        }
    }
}
