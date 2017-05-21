namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVartotojas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vartotojas",
                c => new
                    {
                        Prisijungimo_vardas = c.String(nullable: false, maxLength: 128),
                        Vardas = c.String(nullable: false),
                        Pavarde = c.String(nullable: false),
                        Slaptazodis = c.String(nullable: false),
                        El_pastas = c.String(nullable: false),
                        Gimimo_data = c.DateTime(),
                        Ar_uzblokuotas = c.Byte(),
                        Miestas = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Prisijungimo_vardas);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vartotojas");
        }
    }
}
