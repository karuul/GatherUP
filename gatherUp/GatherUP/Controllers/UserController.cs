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
            return View();
        }

        public RedirectToRouteResult Administrator()
        {
            return RedirectToAction("Index", "Administrator");
        }

        public RedirectToRouteResult Member()
        {
            return RedirectToAction("Index", "Member");
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