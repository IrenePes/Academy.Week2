using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Library.Entities
{
    internal class Book : Doc
    {
        public string? ISBN { get; set; }
        public int? Pages { get; set; }

    }
}