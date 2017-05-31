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
        private readonly ApplicationDbContext _context;
        private readonly VartotojasRepository _interfeis = new VartotojasRepository(new ApplicationDbContext());

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
            return View(_interfeis.GetAll());
        }

        public ViewResult BlockUser(string Prisijungimo_vardas)
        {
            Vartotojas tikrasVartotojas = _interfeis.GetById(Prisijungimo_vardas);

            if (tikrasVartotojas != null)
            {
                tikrasVartotojas.Ar_uzblokuotas = (byte?) (tikrasVartotojas.Ar_uzblokuotas == 0 ? 1 : 0);
                _interfeis.EditUser(tikrasVartotojas);
            }
            return View("Index", _interfeis.GetAll());
        }

        [HttpPost]
        public ViewResult RegisterManager(Vartotojas vartotojas)
        {
            if (ModelState.IsValid)
            {
                vartotojas.VartotojoTipas = VartotojoTipas.savininkas;
                vartotojas.Ar_uzblokuotas = 0;
                _interfeis.RegisterManager(vartotojas);
                return View("Index", _interfeis.GetAll());
            }
            return View();
        }

        public ViewResult RegisterManager()
        {
            return View();
        }

        public ActionResult EditUser(string Prisijungimo_vardas)
        {
            Vartotojas vartotojas = _interfeis.GetById(Prisijungimo_vardas);

            if (vartotojas == null)
            {
                return HttpNotFound();
            }
            return View(vartotojas);
        }

        [HttpPost]
        public ViewResult EditUser(Vartotojas vartotojas)
        {
            _interfeis.EditUser(vartotojas);
            return View("Index", _interfeis.GetAll());
        }
    }
}