using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUP.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }

        public Busena Busena { get; set; }

        public DateTime Data { get; set; }

        public string Zinute { get; set; }

        public UzsakytosPaslaugos UzsakytosPaslaugos { get; set; }

        public ICollection<Pakvietimas> Pakvietimas { get; set; }
    }
}