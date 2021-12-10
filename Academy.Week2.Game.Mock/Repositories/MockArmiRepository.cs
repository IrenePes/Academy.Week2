using Academy.Week2.Game.Core.Entities;
using Academy.Week2.Game.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Mock.Repositories
{
    public class MockArmiRepository : IArmiRepository
    {
        public IEnumerable<Arma> FetchAll(Func<Arma, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.Armi.Where(filter);

            return InMemoryStorage.Armi;
        }
    }
}
