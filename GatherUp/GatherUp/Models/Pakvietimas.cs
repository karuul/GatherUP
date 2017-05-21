using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUP.Models
{
    public class Pakvietimas
    {
        public int Id { get; set; }

        public string Zinute { get; set; }

        public Busena Busena { get; set; }

        public int? SiuntejoId { get; set; }
    }
}