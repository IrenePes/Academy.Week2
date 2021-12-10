using Academy.Week2.Game.Core.Entities;
using Academy.Week2.Game.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.BussinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IArmiRepository _armiRepository;
        private readonly IEroiRepository _eroiRepository;
        private readonly IMostriRepository _mostriRepository;
        private readonly IUtentiRepository _utentiRepository;

        public BusinessLayer(IArmiRepository armiRepo, IEroiRepository eroiRepo, IMostriRepository mostriRepo, IUtentiRepository utentiRepo)
        {
            _armiRepository = armiRepo;
            _eroiRepository = eroiRepo;
            _mostriRepository = mostriRepo;
            _utentiRepository = utentiRepo;
        }

        public Utente Accedi(string nickname, string password)
        {
            return _utentiRepository.FetchAll(u => u.NickName == nickname && u.Password == password).FirstOrDefault();
        }

        public bool AddNewEroe(Eroe eroe)
        {
            return _eroiRepository.AddNewEroe(eroe);
        }

        public bool AddNewMostro(Mostro mostro)
        {
            return _mostriRepository.AddNewMostro(mostro);
        }

        public bool AddNewUtente(Utente utente)
        {
            return _utentiRepository.AddNewUtente(utente);
        }

        public bool CheckNickname(string? nickname)
        {
            return !_utentiRepository.FetchAll(u => u.NickName == nickname).Any();
        }

        public bool DeleteEroe(Eroe eroe)
        {
            return _eroiRepository.DeleteEroe(eroe);
        }

        public Arma GetArmaById(int idArma)
        {
            return _armiRepository.FetchAll(a => a.Id == idArma).FirstOrDefault();
        }

        public IEnumerable<Arma> GetArmiByCategory(int category)
        {
            return _armiRepository.FetchAll(a => (int) a.CategoriaArma == category);
        }

        public IEnumerable<Arma> GetArmiByCategory(string arma)
        {
            CategoriaArmaEnum tipoArma;
            Enum.TryParse<CategoriaArmaEnum>(arma, out tipoArma);
            return _armiRepository.FetchAll(a => a.CategoriaArma == tipoArma);
        }

        public IEnumerable<Eroe> GetClassificaEroi()
        {
            IEnumerable<Eroe> eroi = _eroiRepository.FetchAll().OrderByDescending(e => e.PuntiAccumulati).Take(10);
            return eroi;
        }

        public IEnumerable<Eroe> GetEroiByUtente(int id)
        {
            return _eroiRepository.FetchAll(e => e.UtenteId == id);
        }

        public Mostro GetMostroRandom(int livello)
        {
            IEnumerable<Mostro> mostri = _mostriRepository.FetchAll(m => m.Livello <= livello);

            int max = mostri.Count();
            Random rand = new Random();

            return mostri.ElementAt(rand.Next(0, max));
        }

        public IEnumerable<Utente> GetUtenti()
        {
            return _utentiRepository.FetchAll();
        }
    }
}
