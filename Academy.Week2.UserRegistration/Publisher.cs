using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.UserRegistration
{
    internal class Publisher
    {
        public string Name { get; set; }
        public Publisher (string name)
        {
            Name = name;
        }

        public delegate void GiveNews(Publisher p, Notification notification);

        public event GiveNews OnPublish;

        public void Publish()
        {
            if (OnPublish != null)
            {
                Notification newNotification = new Notification("Leggi l'ultima news!", DateTime.Now);

                OnPublish(this, newNotification);
            }

        }

    }
}
