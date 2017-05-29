namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUserIdFromVietaModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vietas", "Istaigos_savininkasId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vietas", "Istaigos_savininkasId", c => c.Int(nullable: false));
        }
    }
}
