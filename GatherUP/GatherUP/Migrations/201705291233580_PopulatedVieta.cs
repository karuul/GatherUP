namespace GatherUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedVieta : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vietas(Pavadinimas, Adresas, Aprasymas, Bendras_ivertinimas, Istaigos_savininkas_Prisijungimo_vardas) VALUES ('Blyninė', 'Kaunakiemio 15', " +
                "'Sveiki, būtinai apsilankykite čia.', 10, " +
                "'gerassavininkas')");
            Sql("INSERT INTO Vietas(Pavadinimas, Adresas, Aprasymas, Bendras_ivertinimas, Istaigos_savininkas_Prisijungimo_vardas) VALUES ('Kiaušinienė', 'Stulginskio 1', " +
                "'Sveiki, kepame labai skanias kiaušinienes. Būtinai užsukite.', 9, " +
                "'gerassavininkas')");
            Sql("INSERT INTO Vietas(Pavadinimas, Adresas, Aprasymas, Bendras_ivertinimas, Istaigos_savininkas_Prisijungimo_vardas) VALUES ('Naminė', 'Klaipėdos 21', " +
                "'Skanūs naminiai skanėstai. Kepame ir šakočius. Viskas namų sąlygomis ir namų kainomis.', 9, " +
                "'savininkas')");
            Sql("INSERT INTO Vietas(Pavadinimas, Adresas, Aprasymas, Bendras_ivertinimas, Istaigos_savininkas_Prisijungimo_vardas) VALUES ('Žmonos Blynai', 'Pramonės pr. 10', " +
                "'Tikri žmonos blynai tau ir tavo draugams. Užsuk su savo žmona, ir gauk 10% nuolaidą viskam. Susitiksime Žmonos blynuose :).', 10, " +
                "'savininkozmona')");
            Sql("INSERT INTO Vietas(Pavadinimas, Adresas, Aprasymas, Bendras_ivertinimas, Istaigos_savininkas_Prisijungimo_vardas) VALUES ('Karakumu asilėlis', 'Vilniaus g. 5', " +
                "'Ar kada nors ragavai egzotiškų patiekalų? ne? Tuomet šis restoranas kaip tik tau. Jame paragausi ne tik egzotiškų gėrybių, bet taip pat ir vynų iš įvairių pasaulio kampelių.', 8, " +
                "'savininkozmona')");
        }
        
        public override void Down()
        {
        }
    }
}
