using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GatherUp.Models
{
    public class Pakvietimas
    {
        public int Id { get; set; }

        public string Zinute { get; set; }

        public Busena Busena { get; set; }

        public int? SiuntejoId { get; set; }

    }
}