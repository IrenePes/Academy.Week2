using Academy.Week2.Game.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Interfaces
{
    public interface IBusinessLayer
    {
        public Utente Accedi(string nickname, string password);
        bool CheckNickname(string? nickname);
        bool AddNewUtente(Utente utente);
        IEnumerable<Eroe> GetEroiByUtente(int id);
        bool DeleteEroe(Eroe eroe);
        IEnumerable<Arma> GetArmiByCategory(int category);
        IEnumerable<Arma> GetArmiByCategory(string arma);
        bool AddNewEroe(Eroe eroe);
        bool AddNewMostro(Mostro mostro);
        IEnumerable<Eroe> GetClassificaEroi();
        IEnumerable<Utente> GetUtenti();
        Mostro GetMostroRandom(int livello);
        Arma GetArmaById(int idArma);
    }
}
