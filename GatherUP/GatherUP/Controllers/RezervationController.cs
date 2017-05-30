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
            //List<Vieta> places = _context.Vietos.ToList();
            List<Vieta> places = _context.Vietos.ToList();
            return View(places);
        }

        public ActionResult RezervationListView()
        {
            //List<Vieta> places = _context.Vietos.ToList();
            List<Rezervacija> places = _context.Rezervacijos.ToList();
            return View(places);
        }

        public ActionResult MyInvitationListView()
        {
            //List<Rezervacija> rezervations = _context
            List<Pakvietimas> pakvietimai = _context.Pakvietimai.ToList();
            return View(pakvietimai);
        }
        
        public ActionResult PlaceRateView(int Prisijungimo_vardas)
        {
            List<Vieta> ats = getPlaceInfo(Prisijungimo_vardas);
            return View(ats);
        }

        public ActionResult RatePlace(int Prisijungimo_vardas)
        {
            Ivertinimas ivertis = new Ivertinimas();
            ivertis.Ivertinimo_balas = Prisijungimo_vardas;
                _context.Ivertinimai.AddOrUpdate(ivertis);
                _context.SaveChanges();
                return View("RezervationListView", _context.Rezervacijos.ToList());
        }

        public ViewResult ChangeState(int Prisijungimo_vardas)
        {
            Rezervacija TikraRezervacija =
                _context.Rezervacijos.SingleOrDefault(c => c.Id == Prisijungimo_vardas);

            if (TikraRezervacija != null)
            {
                if (TikraRezervacija.Busena == 0)
                    TikraRezervacija.Busena = GatherUP.Models.Busena.patvirtinta;
                else
                    TikraRezervacija.Busena = 0;
                _context.Rezervacijos.AddOrUpdate(TikraRezervacija);
                _context.SaveChanges();
            }

            var rezervacijos = getRezervacijos();
            return View("MyRezervationsView", rezervacijos);
        }

        public ViewResult CancelInvitation(int Prisijungimo_vardas)
        {
            Pakvietimas TikrasPakvietimas =
                _context.Pakvietimai.SingleOrDefault(c => c.Id == Prisijungimo_vardas);

            if (TikrasPakvietimas != null)
            {
                if (TikrasPakvietimas.Busena == 0)
                    TikrasPakvietimas.Busena = GatherUP.Models.Busena.patvirtinta;
                else
                    TikrasPakvietimas.Busena = 0;
                _context.Pakvietimai.AddOrUpdate(TikrasPakvietimas);
                _context.SaveChanges();
            }
            var pakvietimai = _context.Pakvietimai.ToList();
            return View("MyInvitationListView", pakvietimai);
        }

        private List<Rezervacija> getRezervacijos() { return _context.Rezervacijos.ToList(); }

        private List<Vieta> getPlaceInfo(int id)
        {
            Vieta ats = _context.Vietos.SingleOrDefault(c => c.Id == id);
            List<Vieta> places = new List<Vieta>();
            places.Add(ats);
            return places;
        }

    }
}