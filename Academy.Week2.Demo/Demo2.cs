using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Demo
{
    // Dichiaro il delegate
    public delegate void Print(string s);

    // Print può essere usato per fare riferimento a metodi che prendono una stringa e non restituiscono niente
    internal class Demo2
    {
        // creo due metodi che fanno proprio le cose richieste dal delegato
        internal static void Print1(string s)
        {
            Console.WriteLine($"**** {s} ****");
        }

        internal static void Print2(string s)
        {
            Console.WriteLine($"---- {s} ----");
        }

        // metodo che prende come parametro un delegato e lo usa per chiamare un metodo
        internal static void Print3(Print print)
        {
            print("Ciao ancora a tutti!");
        }
    }
}
