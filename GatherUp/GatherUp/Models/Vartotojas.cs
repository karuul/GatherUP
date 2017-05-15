using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace GatherUp.Models
{
    public class Vartotojas
    {
        [Key]
        public string Prisijungimo_vardas { get; set; }

        [Required]
        public string Vardas { get; set; }

        [Required]
        public string Pavarde { get; set; }

        [Required]
        public string Slaptazodis { get; set; }

        [Required]
        public string El_pastas { get; set; }

        public DateTime? Gimimo_data { get; set; }

        public byte? Ar_uzblokuotas { get; set; }

        [Required]
        public string Miestas { get; set; }

        public VartotojoTipas VartotojoTipas { get; set; }

        public ICollection<Vieta> Vieta { get; set; }

        public ICollection<Ivertinimas> Ivertinimas { get; set; }

        public ICollection<Recenzija> Recenzija { get; set; }

        public ICollection<Rezervacija> Rezervacija { get; set; }

        public ICollection<Pakvietimas> Pakvietimas { get; set; }
    }
}