using GatherUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GatherUP.ViewModels
{
    public class EditView
    {
        public int id { get; set; }

        public int trinti { get; set; }

        public List<Vieta> list { get; set; }

    }
}