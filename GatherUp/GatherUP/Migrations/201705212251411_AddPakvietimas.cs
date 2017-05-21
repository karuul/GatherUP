namespace GatherUP.Migrations
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
                        Zinute = c.String(),
                        Busena = c.Int(nullable: false),
                        SiuntejoId = c.Int(),
                        Rezervacija_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rezervacijas", t => t.Rezervacija_Id)
                .Index(t => t.Rezervacija_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pakvietimas", "Rezervacija_Id", "dbo.Rezervacijas");
            DropIndex("dbo.Pakvietimas", new[] { "Rezervacija_Id" });
            DropTable("dbo.Pakvietimas");
        }
    }
}
