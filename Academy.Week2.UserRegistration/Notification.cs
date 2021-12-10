using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.UserRegistration
{
    internal class Notification
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }


        public Notification(string message, DateTime date)
        {
            Message = message;
            Date = date;
        }
    }
}
