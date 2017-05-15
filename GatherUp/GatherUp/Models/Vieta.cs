using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUp.Models
{
    public class Vieta
    {
        public int Id { get; set; }

        public string Pavadinimas { get; set; }

        public string Adresas { get; set; }

        public string Aprasymas { get; set; }

        public double Bendras_ivertinimas { get; set; }

        public Vartotojas Istaigos_savininkas { get; set; }

        public int Istaigos_savininkasId { get; set; }

        public ICollection<PapildomaPaslauga> PapildomosPaslaugos { get; set; }

        public ICollection<Ivertinimas> Ivertinimas { get; set; }

        public ICollection<Recenzija> Recenzija { get; set; }

        public ICollection<Rezervacija> Rezervacija { get; set; }
    }
}