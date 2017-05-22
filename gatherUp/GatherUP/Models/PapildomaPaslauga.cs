using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUP.Models
{
    public class PapildomaPaslauga
    {
        public int Id { get; set; }

        public string Pavadinimas { get; set; }

        public double Kaina { get; set; }

        public Vieta Vieta { get; set; }

        public int VietaId { get; set; }
    }
}