

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FetchAll(Func<T, bool> filter = null);

    }
}
