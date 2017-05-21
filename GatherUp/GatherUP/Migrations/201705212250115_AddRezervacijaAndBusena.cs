namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRezervacijaAndBusena : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rezervacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Busena = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Zinute = c.String(),
                        Vieta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vietas", t => t.Vieta_Id)
                .Index(t => t.Vieta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezervacijas", "Vieta_Id", "dbo.Vietas");
            DropIndex("dbo.Rezervacijas", new[] { "Vieta_Id" });
            DropTable("dbo.Rezervacijas");
        }
    }
}
