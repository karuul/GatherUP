namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPapildomaPaslauga : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PapildomaPaslauga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pavadinimas = c.String(unicode: false),
                        Kaina = c.Double(nullable: false),
                        VietaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vieta", t => t.VietaId, cascadeDelete: true)
                .Index(t => t.VietaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PapildomaPaslauga", "VietaId", "dbo.Vieta");
            DropIndex("dbo.PapildomaPaslauga", new[] { "VietaId" });
            DropTable("dbo.PapildomaPaslauga");
        }
    }
}
