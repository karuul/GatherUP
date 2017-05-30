using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GatherUP.Models
{
    public class Vartotojas
    {
        [Key]
        [Display(Name = "Prisijungimo vardas")]
        [Required]
        public string Prisijungimo_vardas { get; set; }

        [Required]
        public string Vardas { get; set; }

        [Required]
        [Display(Name = "Pavardė")]
        public string Pavarde { get; set; }

        [Required]
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        public string Slaptazodis { get; set; }

        [Required]
        [Display(Name = "El. paštas")]
        public string El_pastas { get; set; }

        [Display(Name = "Gimimo data")]
        [DataType(DataType.Date)]
        public DateTime? Gimimo_data { get; set; }

        public byte? Ar_uzblokuotas { get; set; }

        [Required]
        public string Miestas { get; set; }

        public VartotojoTipas VartotojoTipas { get; set; }

        public ICollection<Vieta> Vieta { get; set; }
    }
}