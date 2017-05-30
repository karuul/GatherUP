using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GatherUP.Models;
using System.Data.Entity.Migrations;
using GatherUP.ViewModels;

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

        [HttpPost]
        public ActionResult Places(FormCollection fc, string istrinti)
        {
            var id = Convert.ToInt32(fc["id"]);
            if (string.IsNullOrEmpty(istrinti))
            {
                var delete = _context.Vietos.Where(c => c.Id == id).ToArray();
                _context.Vietos.Remove(delete[0]);
                _context.SaveChanges();
            }else
            {

            }
            var companyOwnerPlacesList = _context.Vietos.ToList();
            return View("Index", companyOwnerPlacesList);
        }

        public ViewResult Place (int id)
        {
            EditView list = new EditView();
            list.list = _context.Vietos.Where(c => c.Id == id).ToList();
            return View(list);
           
        }
        //[HttpPost]
        //public ActionResult Place(string command)
        //{
        //    if (!string.IsNullOrEmpty(command))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        public ActionResult EditPlace(int id)
        {
            Vieta companyOwnerPlacesList = _context.Vietos.Find(id);
            return View(companyOwnerPlacesList);
        }
        [HttpPost]
        public ActionResult EditPlace(Vieta vieta)
        {
            
            _context.Vietos.AddOrUpdate(vieta);
            _context.SaveChanges();

            var companyOwnerPlacesList = _context.Vietos.ToList();
            return View("Index", companyOwnerPlacesList);
        }
    }
}