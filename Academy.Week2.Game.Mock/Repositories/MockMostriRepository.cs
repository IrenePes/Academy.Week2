using Academy.Week2.Game.Core.Entities;
using Academy.Week2.Game.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Mock.Repositories
{
    public class MockMostriRepository : IMostriRepository
    {

        public bool AddNewMostro(Mostro mostro)
        {
            if(mostro == null)
                return false;
            else
            {
                mostro.PuntiVita = mostro.Livello * 20;
                InMemoryStorage.Mostri.Add(mostro);
                return true;
            }
        }

        public IEnumerable<Mostro> FetchAll(Func<Mostro, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.Mostri.Where(filter);
            else
                return InMemoryStorage.Mostri;
        }
    }
}
