using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using GatherUP.Models;

namespace GatherUP.Controllers
{
    public class AdministratorController : Controller
    {
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
            var vartotojai = _context.Vartotojai.ToList();
            return View(vartotojai);
        }

        public ViewResult BlockUser(string Prisijungimo_vardas)
        {
            Vartotojas tikrasVartotojas =
                _context.Vartotojai.SingleOrDefault(c => c.Prisijungimo_vardas == Prisijungimo_vardas);

            if (tikrasVartotojas != null)
            {
                if (tikrasVartotojas.Ar_uzblokuotas == 0)
                    tikrasVartotojas.Ar_uzblokuotas = 1;
                else
                    tikrasVartotojas.Ar_uzblokuotas = 0;
                _context.Vartotojai.AddOrUpdate(tikrasVartotojas);
                _context.SaveChanges();
            }
            var vartotojai = _context.Vartotojai.ToList();
            return View("Index", vartotojai);
        }

        [HttpPost]
        public ViewResult RegisterManager(Vartotojas vartotojas)
        {
            if (ModelState.IsValid)
            {
                vartotojas.VartotojoTipas = VartotojoTipas.savininkas;
                vartotojas.Ar_uzblokuotas = 0;
                _context.Vartotojai.Add(vartotojas);
                _context.SaveChanges();
                var vartotojai = _context.Vartotojai.ToList();
                return View("Index", vartotojai);
            }
            return View();
        }

        public ViewResult RegisterManager()
        {
            return View();
        }

        public ActionResult EditUser(string Prisijungimo_vardas)
        {
            Vartotojas vartotojas = _context.Vartotojai.SingleOrDefault(c => c.Prisijungimo_vardas == Prisijungimo_vardas);

            if (vartotojas == null)
            {
                return HttpNotFound();
            }
            return View(vartotojas);
        }

        [HttpPost]
        public ViewResult EditUser(Vartotojas vartotojas)
        {
            _context.Vartotojai.AddOrUpdate(vartotojas);
            _context.SaveChanges();
            var vartotojai = _context.Vartotojai.ToList();
            return View("Index", vartotojai);
        }
    }
}