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
            //var companyOwnerPlacesList = _context.Vietos.Where(c => c.Istaigos_savininkas.Prisijungimo_vardas == "savininkozmona").ToList();
            //return View(companyOwnerPlacesList);

            var companyOwnerPlacesList = _context.Vietos.ToList();
            return View(companyOwnerPlacesList);

        }

        public ViewResult RegisterPlace(Vieta vieta)
        {
            if (vieta.Pavadinimas != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Vietos.Add(vieta);
                    _context.SaveChanges();
                    var companyOwnerPlacesList = _context.Vietos.ToList();
                    return View("Index", companyOwnerPlacesList);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

       public ActionResult Place(int id)
        {
            var companyOwnerPlacesList = _context.Vietos.Where(c => c.Id == id).ToList();
            return View(companyOwnerPlacesList);
        }

        public ActionResult EditPlace(int id)
        {
            Vieta companyOwnerPlacesList = _context.Vietos.Find(id);
            return View(companyOwnerPlacesList);
        }
        public ActionResult EditPlace(Vieta vieta)
        {
            

            var companyOwnerPlacesList = _context.Vietos.ToList();
            return View("Index", companyOwnerPlacesList);
        }
    }
}