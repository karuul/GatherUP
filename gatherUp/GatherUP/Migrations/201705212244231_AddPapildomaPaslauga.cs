namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPapildomaPaslauga : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PapildomaPaslaugas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pavadinimas = c.String(),
                        Kaina = c.Double(nullable: false),
                        VietaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vietas", t => t.VietaId, cascadeDelete: true)
                .Index(t => t.VietaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PapildomaPaslaugas", "VietaId", "dbo.Vietas");
            DropIndex("dbo.PapildomaPaslaugas", new[] { "VietaId" });
            DropTable("dbo.PapildomaPaslaugas");
        }
    }
}
