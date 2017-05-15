namespace GatherUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPavadinimasToVieta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vieta", "Pavadinimas", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vieta", "Pavadinimas");
        }
    }
}
