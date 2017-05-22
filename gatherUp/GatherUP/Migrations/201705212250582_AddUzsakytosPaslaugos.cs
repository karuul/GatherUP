namespace GatherUP.Migrations
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
                        Pavadinimas = c.String(),
                        Kaina = c.Double(nullable: false),
                        Kiekis = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rezervacijas", "UzsakytosPaslaugos_Id", c => c.Int());
            CreateIndex("dbo.Rezervacijas", "UzsakytosPaslaugos_Id");
            AddForeignKey("dbo.Rezervacijas", "UzsakytosPaslaugos_Id", "dbo.UzsakytosPaslaugos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezervacijas", "UzsakytosPaslaugos_Id", "dbo.UzsakytosPaslaugos");
            DropIndex("dbo.Rezervacijas", new[] { "UzsakytosPaslaugos_Id" });
            DropColumn("dbo.Rezervacijas", "UzsakytosPaslaugos_Id");
            DropTable("dbo.UzsakytosPaslaugos");
        }
    }
}
