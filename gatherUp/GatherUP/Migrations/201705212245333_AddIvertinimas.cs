namespace GatherUP.Migrations
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
                        Komentaras = c.String(),
                        Vieta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vietas", t => t.Vieta_Id)
                .Index(t => t.Vieta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ivertinimas", "Vieta_Id", "dbo.Vietas");
            DropIndex("dbo.Ivertinimas", new[] { "Vieta_Id" });
            DropTable("dbo.Ivertinimas");
        }
    }
}
