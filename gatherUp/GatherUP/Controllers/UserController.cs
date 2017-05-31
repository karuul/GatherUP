using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using GatherUP.Models;
using GatherUP.ViewModels;

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
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VartotojasLogin vartotojas)
        {
            if (ModelState.IsValid)
            {
                Vartotojas tikrasVartotojas =
                    _context.Vartotojai.SingleOrDefault(c => c.Prisijungimo_vardas == vartotojas.Prisijungimo_vardas);

                if (tikrasVartotojas == null)
                {
                    ModelState.AddModelError("Prisijungimo_vardas", "Prisijungimas nepavyko");
                    return View();
                }

                if (tikrasVartotojas.Ar_uzblokuotas == 1)
                {
                    ModelState.AddModelError("Prisijungimo_vardas", "Vartotojas užblokuotas");
                    return View();
                }

                if (!tikrasVartotojas.Prisijungimo_vardas.Equals(vartotojas.Prisijungimo_vardas))
                {
                    ModelState.AddModelError("Prisijungimo_vardas", "Prisijungimas nepavyko");
                    return View();
                }
                if (!tikrasVartotojas.Slaptazodis.Equals(vartotojas.Slaptazodis))
                {
                    ModelState.AddModelError("Prisijungimo_vardas", "Prisijungimas nepavyko");
                    return View();
                }

                //Prisijungimas sėkmingas
                switch (vartotojas.Prisijungimo_vardas)
                {
                    case "vartotojas":
                        return RedirectToAction("Index", "Rezervation");
                    case "savininkas":
                        return RedirectToAction("Index", "CompanyOwner");
                    case "vadybininkas":
                        return RedirectToAction("Index", "RegionManager");
                    case "administratorius":
                        return RedirectToAction("Index", "Administrator");
                    default:
                        return RedirectToAction("Index", "User");
                }
                //vartotojas.VartotojoTipas = VartotojoTipas.narys;
                //vartotojas.Ar_uzblokuotas = 0;
                //_context.Vartotojai.Add(vartotojas);
                //_context.SaveChanges();
            }
            return View();
        }
    }
}