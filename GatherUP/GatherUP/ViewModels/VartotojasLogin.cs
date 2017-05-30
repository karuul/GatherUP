using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GatherUP.ViewModels
{
    public class VartotojasLogin
    {
        [Display(Name = "Prisijungimo vardas")]
        public string Prisijungimo_vardas { get; set; }
        
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        public string Slaptazodis { get; set; }
    }
}