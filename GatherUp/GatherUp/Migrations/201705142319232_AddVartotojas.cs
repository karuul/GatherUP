namespace GatherUp.Migrations
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
                        Prisijungimo_vardas = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Vardas = c.String(nullable: false, unicode: false),
                        Pavarde = c.String(nullable: false, unicode: false),
                        Slaptazodis = c.String(nullable: false, unicode: false),
                        El_pastas = c.String(nullable: false, unicode: false),
                        Gimimo_data = c.DateTime(precision: 0),
                        Ar_uzblokuotas = c.Byte(),
                        Miestas = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Prisijungimo_vardas);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vartotojas");
        }
    }
}
