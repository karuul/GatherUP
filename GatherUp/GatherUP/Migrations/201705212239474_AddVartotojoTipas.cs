namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVartotojoTipas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vartotojas", "VartotojoTipas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vartotojas", "VartotojoTipas");
        }
    }
}
