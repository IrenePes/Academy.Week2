using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Demo
{
    public struct Coordinates // struttura che contiene le coordinate dei punti del piano cartesiano 
    {
        public int x;
        public int y;
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Circle
    {
        public double Radius { get; set; }
        // public double X { get; set; } // coordinata X del centro
        //public double Y { get; set; } // coordinata Y del centro

        //public Circle(double radius, double x, double y)
        //{
        //    Radius = radius;
        //    X = x;
        //    Y = y;
        //}

        public Coordinates Center { get; set; } = new Coordinates();

        public Circle (double radius, Coordinates coordinates)
        {
            Radius = radius;
            Center = coordinates;
        }

        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }
    
    }


    internal class Demo1
    {
        public static void DemoStruct()
        {
            // Inizializzare un oggetto di tipo Coordinates 

            Coordinates coordinates = new Coordinates();
            coordinates.x = -2;
            coordinates.y = 3;

            Coordinates coordinates2 = new Coordinates(-2, 3);

            // utilizzo come tipo in una classe
            
            Circle circle = new Circle(3.2, coordinates);

            Coordinates coordinates3; // lo inizializza a (0,0) perchè un tipo di valore
            Circle circle2; // lo inizializza a null

        }

        public static void DemoNullableTypes()
        {
            Circle circle; // non sto creando un'istanza dunque punta a null
            Circle circle2 = null; // circle è ref type dunque ammette => null

            // int a = null; // non posso assegnare null a un value type (deve per forza contenere un valore)

            int? a = null; // posso assegnare null a un intero perchè l'ho reso nullabile

            int c; // 0
            int? b; // null
            b = 20;

            // se voglio incapsulare il tipo nella struct Nullable
            Nullable<int> d;    // è la stessa cosa di int? d;

            // ci sono operatori particolari che agiscono proprio sulla questione null/non null

            // se l'intero b ha valore mi da il valore altrimenti 0
            int e;
            if (b.HasValue)
                e = b.Value;
            else e = 0;

            // possiamo raggruppare il tutto usando un operatore ternario
            int f = b.HasValue ? b.Value : 0;

            // operatore ??
            circle2 ??= new Circle(2.3, new Coordinates(3, 4));

            // l'operatore ?? si traduce così:
            if (circle2 == null)
                circle2 = new Circle(2.3, new Coordinates(3, 4));

            Circle circle3 = null;

            // operatore ?.

            // se circle2 è null restituisce null altrimenti il raggio
            double? r2 = circle3?.Radius;

            // equivale a
            r2 = (circle3 != null) ? (double)circle3.Radius : null;

            // combiniamo un po' le cose
            double r3 = circle3?.Radius ?? 0; 

            // equivale a
            r3 = (circle3 != null) ? circle3.Radius : 0;
        }    
    }
}
