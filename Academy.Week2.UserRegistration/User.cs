using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.UserRegistration
{
    internal class User
    {
        public string UserName { get; set; }
        public int Age { get; set; }

        public bool IsAdult(User user)
        {
            if (user.Age > 18)
                return true;
            else
                return false;
        }

        // Metodo subscribe/unsubscribe

        public void Subscribe(Publisher p)
        {
            p.OnPublish += OnNotificationReceived;
        }

        // Metodo che gestisce la ricezione della notifica

        public void OnNotificationReceived(Publisher p, Notification n)
        {
            Console.WriteLine($"Ciao {UserName}! {n.Message} - {n.Date} da {p.Name}");
        }
    }
}
