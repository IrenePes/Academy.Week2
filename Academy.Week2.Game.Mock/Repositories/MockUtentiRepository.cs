using Academy.Week2.Game.Core.Entities;
using Academy.Week2.Game.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Mock.Repositories
{
    public class MockUtentiRepository : IUtentiRepository
    {
        public bool AddNewUtente(Utente utente)
        {
            utente.IsAdmin = false;
            utente.Id = InMemoryStorage.Utenti.Max(u => u.Id) + 1;
            InMemoryStorage.Utenti.Add(utente);
            return true;
        }

        public IEnumerable<Utente> FetchAll(Func<Utente, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.Utenti.Where(filter);

            return InMemoryStorage.Utenti;
        }
    }
}
