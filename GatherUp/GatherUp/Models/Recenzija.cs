using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUp.Models
{
    public class Recenzija
    {
        public int Id { get; set; }

        public int Ivertinimo_balas { get; set; }

        public string Tekstas { get; set; }

    }
}