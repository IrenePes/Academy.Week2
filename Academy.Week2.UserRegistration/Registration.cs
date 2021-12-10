using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.UserRegistration
{
    // Facciamo in modo che chi crea oggetti di tipo Registration, sceglie il metodo con cui inviare la notifica
     public delegate void NotifyUser(string s);

    internal class Registration
    {
        // Definiamo oggetto di tipo NotifyUser per agganciare metodo che prende stringa e restituisce void
        NotifyUser notifyUser;

        public Registration (NotifyUser notifyUser)
        {
            this.notifyUser = notifyUser;
        }

        // Metodo che controlla se tutti i campi sono compilati e poi manda la notifica 
        public void CheckFields(string s)
        {
            notifyUser(s);
        }

        //Func<T1, T2, TF> -> per metodi non void
        //TF -> tipo di ritorno
        //Tutti gli altri -> parametri di ingresso
        public void Welcome(char sex, string name, Func<char, string, string> welcome)
        {
            Console.WriteLine(welcome(sex, name));
        }

        //Predicate<T> -> per metodi boolean
        public void ShowContents(User user, Predicate<User> isAdult)
        {
            if (isAdult(user))
                Console.WriteLine("Contenuto visibile");
            else
                Console.WriteLine("Contenuto nascosto");
        }

        // 2 metodi di notifica
        public static void NotifyUserByEmail(string email)
        {
            Console.WriteLine($"E' stata inviata una mail di verifica all'indirizzo e-mail che hai indicato: {email}");
        }

        public static void NotifyUserBySMS(string number)
        {
            Console.WriteLine($"E' stato inviato un sms di verifica al numero che hai indicato: {number}");
        }

        // 2 metodi per dare il benvenuto
        public static string DaiBenvenuto(char sex, string name)
        {
            if (sex == 'F')
                return $"Benvenuta {name}";
            else if (sex == 'M')
                return $"Benvenuto {name}";
            else
                return "Benvenut*";
        }

        public static string SayWelcome(char sex, string name)
        {
            if (sex == 'F')
                return $"Welcome Miss {name}";
            else if (sex == 'M')
                return $"Welcome Mister {name}";
            else
                return "Welcome";
        }
    }
}
