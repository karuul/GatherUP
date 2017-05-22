namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVartotojas : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vartotojas(Prisijungimo_vardas, Vardas, Pavarde, Slaptazodis, El_pastas, Gimimo_data, Ar_uzblokuotas, Miestas, VartotojoTipas) VALUES ('administratorius', 'Adminas', 'Adminaitis', 'labas', 'adminas@gatherup.lt', 1994-08-18, 0, 'Kaunas', 1)");
            Sql("INSERT INTO Vartotojas(Prisijungimo_vardas, Vardas, Pavarde, Slaptazodis, El_pastas, Gimimo_data, Ar_uzblokuotas, Miestas, VartotojoTipas) VALUES ('vadybininkas', 'Vadovas', 'Vadovaitis', 'labas', 'vadovas@gatherup.lt', 1990-08-10, 0, 'Vilnius', 3)");
            Sql("INSERT INTO Vartotojas(Prisijungimo_vardas, Vardas, Pavarde, Slaptazodis, El_pastas, Gimimo_data, Ar_uzblokuotas, Miestas, VartotojoTipas) VALUES ('vartotojas', 'Vartotoja', 'Vartotojaitis', 'labas', 'vartotojas@gatherup.lt', 2000-01-01, 0, 'Telse', 4)");
        }
        
        public override void Down()
        {
        }
    }
}
