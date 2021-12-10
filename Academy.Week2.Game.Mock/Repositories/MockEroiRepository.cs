using Academy.Week2.Game.Core.Entities;
using Academy.Week2.Game.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Mock.Repositories
{
    public class MockEroiRepository : IEroiRepository
    {
        public bool AddNewEroe(Eroe eroe)
        {
            eroe.Id = InMemoryStorage.Eroi.Max(e => e.Id) + 1;
            eroe.Livello = 1;
            eroe.PuntiVita = 20;
            eroe.PuntiAccumulati = 0;

            InMemoryStorage.Eroi.Add(eroe);
            return true;

            if(eroe == null)
                return false;
        }

        public bool DeleteEroe(Eroe eroe)
        {
            if(eroe == null)
                return false;
            return InMemoryStorage.Eroi.Remove(eroe);
        }

        public IEnumerable<Eroe> FetchAll(Func<Eroe, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.Eroi.Where(filter);
            else
                return InMemoryStorage.Eroi;
        }
    }
}
