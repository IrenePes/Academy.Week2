using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            return $"Utente ID: {Id}\n" +
                $"Nickname: {NickName}\n" +
                $"Amministratore: {IsAdmin}\n";
        }
    }
}
