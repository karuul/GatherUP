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

        public ViewResult Administrator()
        {
            //var usersList = _context.Vartotojas.ToList();
            Vartotojas vartotojas = new Vartotojas
            {
                Prisijungimo_vardas = "labas",
                Vardas = "vardas"
            };
            List<Vartotojas> usersList = new List<Vartotojas>();
            usersList.Add(vartotojas);

            return View("~/Views/Administrator/Index.cshtml", usersList);
        }
    }
}