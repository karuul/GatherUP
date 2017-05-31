using System.Collections.Generic;
using GatherUP.Models;

namespace GatherUP.Interfaces
{
    public interface IVartotojasRepository
    {
        Vartotojas GetById(string prisijungimoVardas);

        void RegisterManager(Vartotojas vartotojas);

        void EditUser(Vartotojas vartotojas);

        List<Vartotojas> GetAll();
    }
}