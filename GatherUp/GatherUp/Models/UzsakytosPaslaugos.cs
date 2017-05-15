using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUp.Models
{
    public class UzsakytosPaslaugos
    {
        public int Id { get; set; }

        public string Pavadinimas { get; set; }

        public double Kaina { get; set; }

        public int Kiekis { get; set; }
    }
}