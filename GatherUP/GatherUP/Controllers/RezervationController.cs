﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GatherUP.Models;

namespace GatherUP.Controllers
{
    public class RezervationController : Controller
    {
        private ApplicationDbContext _context;

        public RezervationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            List<Vieta> places = _context.Vietos.ToList();
            return View(places);
        }
    }
}