using GatherUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using GatherUP.Interfaces;

namespace GatherUP.Controllers
{
    public class VartotojasRepository : IVartotojasRepository
    {
        private readonly ApplicationDbContext _context;

        public VartotojasRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public void RegisterManager(Vartotojas vartotojas)
        {
            vartotojas.VartotojoTipas = VartotojoTipas.savininkas;
            vartotojas.Ar_uzblokuotas = 0;
            _context.Vartotojai.Add(vartotojas);
            _context.SaveChanges();
        }
        
        public void EditUser(Vartotojas vartotojas)
        {
            _context.Vartotojai.AddOrUpdate(vartotojas);
            _context.SaveChanges();
        }

        public List<Vartotojas> GetAll()
        {
            List<Vartotojas> vartotojai = new List<Vartotojas>();
            vartotojai = _context.Vartotojai.ToList();
            return vartotojai;
        }

        public Vartotojas GetById(string prisijungimoVardas)
        {
            Vartotojas tikrasVartotojas =
                _context.Vartotojai.SingleOrDefault(c => c.Prisijungimo_vardas == prisijungimoVardas);
            return tikrasVartotojas;
        }
    }
}