using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GatherUP.Models;

namespace GatherUP.Controllers
{
    public class CompanyOwnerController : Controller
    {
        private ApplicationDbContext _context;

        public CompanyOwnerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var companyOwnerPlacesList = _context.Vietos.Where(c => c.Istaigos_savininkas.Prisijungimo_vardas == "savininkozmona").ToList();
            return View(companyOwnerPlacesList);
        }
    }
}