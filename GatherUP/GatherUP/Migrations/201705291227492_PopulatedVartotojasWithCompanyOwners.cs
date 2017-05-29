namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedVartotojasWithCompanyOwners : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vartotojas(Prisijungimo_vardas, Vardas, Pavarde, Slaptazodis, El_pastas, Gimimo_data, Ar_uzblokuotas, Miestas, VartotojoTipas) VALUES ('savininkas', 'Paulius', 'Krašas', 'labas', 'paulius@gatherup.lt', 1985-08-18, 0, 'Klaipeda', 2)");
            Sql("INSERT INTO Vartotojas(Prisijungimo_vardas, Vardas, Pavarde, Slaptazodis, El_pastas, Gimimo_data, Ar_uzblokuotas, Miestas, VartotojoTipas) VALUES ('savininkozmona', 'Antanina', 'Krašienė', 'labas', 'antanina@gatherup.lt', 1984-08-10, 0, 'Vilnius', 2)");
            Sql("INSERT INTO Vartotojas(Prisijungimo_vardas, Vardas, Pavarde, Slaptazodis, El_pastas, Gimimo_data, Ar_uzblokuotas, Miestas, VartotojoTipas) VALUES ('gerassavininkas', 'Jurgis', 'Gerulis', 'labas', 'jurgis@gatherup.lt', 1972-01-01, 0, 'Zapyskis', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
