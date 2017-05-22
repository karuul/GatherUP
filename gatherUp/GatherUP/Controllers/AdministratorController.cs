using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
            var vartotojai = _context.Vartotojai;
            return View(vartotojai);
        }
    }
}