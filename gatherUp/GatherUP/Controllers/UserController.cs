using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GatherUP.Models;

namespace GatherUP.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            List<Vieta> places = _context.Vietos.ToList();
            return View(places);
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Vartotojas vartotojas)
        {
            if (ModelState.IsValid)
            {
                vartotojas.VartotojoTipas = VartotojoTipas.narys;
                vartotojas.Ar_uzblokuotas = 0;
                _context.Vartotojai.Add(vartotojas);
                _context.SaveChanges();
            }
            return View("Register");
        }
        
        //[HttpPost]
        public ActionResult Login(string vardas, string slaptazodis)
        {
            if (ModelState.IsValid)
            {
                Vartotojas tikrasVartotojas =
                    _context.Vartotojai.SingleOrDefault(c => c.Prisijungimo_vardas == vardas);

                if (tikrasVartotojas == null) return View();

                if (!tikrasVartotojas.Prisijungimo_vardas.Equals(vardas))
                {
                    ModelState.AddModelError("Prisijungimo_vardas", "Prisijungimas nepavyko");
                    return View();
                }
                else if (!tikrasVartotojas.Slaptazodis.Equals(slaptazodis))
                {
                    ModelState.AddModelError("Prisijungimo_vardas", "Prisijungimas nepavyko");
                    return View();
                }

                //Prisijungimas sėkmingas
                return View("Index");

                //vartotojas.VartotojoTipas = VartotojoTipas.narys;
                //vartotojas.Ar_uzblokuotas = 0;
                //_context.Vartotojai.Add(vartotojas);
                //_context.SaveChanges();
            }
            return View();
        }

        public RedirectToRouteResult Administrator()
        {
            return RedirectToAction("Index", "Administrator");
        }

        public RedirectToRouteResult Rezervation()
        {
            return RedirectToAction("Index", "Rezervation");
        }

        public RedirectToRouteResult CompanyOwner()
        {
            return RedirectToAction("OwnerIndex", "CompanyOwner", new { istaigosSavininkas = "savininkozmona"});
        }

        public RedirectToRouteResult RegionManager()
        {
            return RedirectToAction("Index", "RegionManager");
        }

        public ViewResult Manager()
        {
            List<Vartotojas> users = _context.Vartotojai.ToList();

            return View("~/Views/Administrator/Index.cshtml", users);
        }

    }
}