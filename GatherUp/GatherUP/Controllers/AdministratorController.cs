using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GatherUP.Models;

namespace GatherUP.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        private ApplicationDbContext _context;

        public AdministratorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ViewResult Index()
        {
            Vartotojas var = new Vartotojas
            {
                Vardas = "labas",
                Prisijungimo_vardas = "labas"
            };
            return View(var);
        }
    }
}