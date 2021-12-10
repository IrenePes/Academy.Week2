using Academy.Week2.Game.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Interfaces
{
    public interface IMostriRepository : IRepository<Mostro>
    {
        bool AddNewMostro(Mostro mostro);

        public IEnumerable<Mostro> FetchAll(Func<Mostro, bool> filter = null);

    }
}
