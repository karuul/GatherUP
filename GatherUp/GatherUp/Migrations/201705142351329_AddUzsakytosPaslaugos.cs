namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUzsakytosPaslaugos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UzsakytosPaslaugos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pavadinimas = c.String(unicode: false),
                        Kaina = c.Double(nullable: false),
                        Kiekis = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rezervacija", "UzsakytosPaslaugos_Id", c => c.Int());
            CreateIndex("dbo.Rezervacija", "UzsakytosPaslaugos_Id");
            AddForeignKey("dbo.Rezervacija", "UzsakytosPaslaugos_Id", "dbo.UzsakytosPaslaugos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezervacija", "UzsakytosPaslaugos_Id", "dbo.UzsakytosPaslaugos");
            DropIndex("dbo.Rezervacija", new[] { "UzsakytosPaslaugos_Id" });
            DropColumn("dbo.Rezervacija", "UzsakytosPaslaugos_Id");
            DropTable("dbo.UzsakytosPaslaugos");
        }
    }
}
