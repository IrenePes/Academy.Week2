using Academy.Week2.Game.Core.BussinessLayer;
using Academy.Week2.Game.Core.Entities;
using Academy.Week2.Game.Core.Interfaces;
using Academy.Week2.Game.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Client
{
    public class Menu1
    {
        private static readonly IBusinessLayer mainBL = new BusinessLayer(new MockArmiRepository(), new MockEroiRepository(), new MockMostriRepository(), new MockUtentiRepository());
        public static void Start()
        {
            // Console.BackgroundColor = ConsoleColor.Yellow;
            // Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Benvenuto!");

            char choice;

            do
            {
                Console.WriteLine("[1] Accedi al gioco" +
                    "\n[2] Registrati al gioco" +
                    "\n[Q] Esci");
                // Console.ResetColor();
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        AccediGioco();
                        break;
                    case '2':
                        RegistratiGioco();
                        break;
                    case 'Q':
                        Console.WriteLine("\nAlla prossima partita!");
                        return;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova!");
                        break;
                }

            } while (!(choice == 'Q'));
        }

        private static void RegistratiGioco()
        {
            string nickname;
            bool var;
            do
            {

                Console.WriteLine("Inserire nome utente: ");
                nickname = Console.ReadLine();

                var = mainBL.CheckNickname(nickname);
                if(!var)
                    Console.WriteLine("Nickname già esistente, scegline un altro");

            } while (!var);

            Console.WriteLine("Inserire password: ");
            string password = Console.ReadLine();

            Utente utente = new Utente()
            {
                NickName = nickname,
                Password = password
            };

            bool add = mainBL.AddNewUtente(utente);

            if (add == true)
            {
                Console.WriteLine("Registrazione avvenuta con successo");

                MenuNonAdmin(utente);
            }


        }

        private static void AccediGioco()
        {
            Console.WriteLine("Inserire nome utente: ");
            string nickname = Console.ReadLine();
            Console.WriteLine("Inserire password: ");
            string password = Console.ReadLine();

            Utente utente = mainBL.Accedi(nickname, password);

            if (utente == null)
                Console.WriteLine("Username e/o password errati");
            else
            {
                if (utente.IsAdmin)
                    MenuAdmin(utente);
                else
                    MenuNonAdmin(utente);
            }

        }

        private static void MenuNonAdmin(Utente utente)
        {
            char choice;

            do
            {
                Console.WriteLine("[1] Gioca" +
                    "\n[2] Crea un nuovo eroe" +
                    "\n[3] Elimina un eroe" +
                    "\n[Q] Esci");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Gioca(utente);
                        break;
                    case '2':
                        CreaNuovoEroe(utente);
                        break;
                    case '3':
                        CancellaEroe(utente);
                        break;
                    case 'Q':
                        return;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova!");
                        break;
                }

            } while (!(choice == 'Q'));


        }

        private static void CancellaEroe(Utente utente)
        {
            IEnumerable<Eroe> eroiByUtente = mainBL.GetEroiByUtente(utente.Id);

            StampaEroi(eroiByUtente);

            if (eroiByUtente.Any())
            {

                Console.WriteLine("Inserisci l'Id dell'eroe che vuoi eliminare:");

                int id;

                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Inserisci un valore valido!");
                }

                bool var = mainBL.DeleteEroe(eroiByUtente.Where(e => e.Id == id).FirstOrDefault());

                if (var)
                    Console.WriteLine("L'eroe è stato cancellato con successo");
                else
                    Console.WriteLine("Eliminazione annullata");
            }

        }

        private static void StampaEroi(IEnumerable<Eroe> eroiByUtente)
        {
            if (eroiByUtente.Count() == 0)
                Console.WriteLine("Non possiedi alcun eroe");

            foreach (Eroe e in eroiByUtente)
                Console.WriteLine(e.ToString());
        }

        private static void CreaNuovoEroe(Utente utente)
        {
            Console.WriteLine("Inserire nome dell'eroe:");

            string nomeEroe = Console.ReadLine();

            Console.WriteLine("Scegli categoria eroe:");

            int i = 1;
            foreach (string categoria in Enum.GetNames(typeof(TipoEroeEnum)))
            {
                Console.WriteLine(i + " " + categoria);
                i++;
            }
            int category;

            while (!int.TryParse(Console.ReadLine(), out category) || category >= i)
            {
                Console.WriteLine("Inserisci un valore valido");
            }

            Console.WriteLine("Seleziona arma");

            TipoEroeEnum tipoArma = (TipoEroeEnum)category;
            string arma = $"Arma{tipoArma}";
            IEnumerable<Arma> armi = mainBL.GetArmiByCategory(arma);
            StampaArmi(armi);

            int idArma;
            while (!int.TryParse(Console.ReadLine(), out idArma) || !armi.Where(a => a.Id == idArma).Any())
            {
                Console.WriteLine("Inserisci un valore valido");
            }

            Eroe eroe = new Eroe();

            eroe.NomeEroe = nomeEroe;
            eroe.ArmaId = idArma;
            eroe.TipoEroe = (TipoEroeEnum)category;
            eroe.UtenteId = utente.Id;

            bool verify = mainBL.AddNewEroe(eroe);

            if (verify)
                Console.WriteLine("Eroe inserito con successo");
        }

        private static void StampaArmi(IEnumerable<Arma> armi)
        {
            foreach (Arma arma in armi)
                Console.WriteLine(arma.ToString());
        }

        private static void Gioca(Utente utente)
        {
            IEnumerable<Eroe> eroes = mainBL.GetEroiByUtente(utente.Id);
            StampaEroi(eroes);
            if (eroes.Any())
            {
                Eroe eroe;
                Console.WriteLine("Inserisci Id dell'eroe con cui giocare");

                do
                {
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Inserisci un valore valido");
                    }
                    eroe = eroes.Where(e => e.Id == id).FirstOrDefault();

                    if (eroe == null)
                        Console.WriteLine("Id sbagliato");

                } while (eroe == null);


                GamePlay(eroe, utente);
            }
        }

        private static void GamePlay(Eroe eroe, Utente utente)
        {
            Mostro nemico = mainBL.GetMostroRandom(eroe.Livello);

            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"Stai combattendo con il mostro {nemico.ToString()}");
            Console.ResetColor();

            int fullVitaMostro = nemico.PuntiVita;
            int fullVitaEroe = eroe.PuntiVita;

            bool turnoEroe = true;
            bool fineBattaglia;

            do
            {
                fineBattaglia = turnoEroe ? TurnoEroe(eroe, nemico) : TurnoMostro(nemico, eroe);
                turnoEroe = !turnoEroe;
            
            } while (!fineBattaglia);

            eroe.PuntiVita = fullVitaEroe;
            nemico.PuntiVita = fullVitaMostro;


            if(eroe.Livello >= 3)
                utente.IsAdmin = true;

            if (ContinuaACombattere())
            {
                if(CambiaEroe())
                    Gioca(utente);
                else
                    GamePlay(eroe, utente);
            }
        }

        private static bool ContinuaACombattere()
        {
            char choice;
            bool continua = false;

            do
            {
                Console.WriteLine("[1] Continua" +
                    "\n[2] Esci");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        continua = true;
                        break;
                    case '2':
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova!");
                        break;
                }

            } while (choice == 1 || choice == 2);

            return continua;
        }

        private static bool CambiaEroe()
        {
            char choice;
            bool cambio = false;

            do
            {
                Console.WriteLine("[1] Cambia eroe" +
                    "\n[2] Continua con lo stesso eroe");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        cambio = true;
                        break;
                    case '2':
                        cambio = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova!");
                        break;
                }

            } while (choice == 1 || choice == 2);

            return cambio;
        }

        private static bool TurnoMostro(Mostro nemico, Eroe eroe)
        {
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Turno del mostro");
            Arma arma = mainBL.GetArmaById(nemico.IdArma);
            int puntiDanno = arma.PuntiDanno;
            Console.WriteLine($"Il mostro infligge un danno di {puntiDanno}");
            eroe.PuntiVita -= puntiDanno;
            Console.WriteLine($"Punti rimanenti del giocatore dopo l'attacco: {(eroe.PuntiVita < 0 ? 0 : eroe.PuntiVita)}");
            Console.ResetColor();
            return eroe.PuntiVita <= 0;
        }

        private static bool TurnoEroe(Eroe eroe, Mostro nemico)
        {
            char choice;
            bool fineBattaglia = false;

            do
            {
                //Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Turno dell'eroe");
                
                Console.WriteLine("[1] Attacca" +
                    "\n[2] Fuggi");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        fineBattaglia = Attacco(eroe, nemico);
                        if(fineBattaglia)
                        {
                            Console.WriteLine($"Hai vinto! Guadagni {nemico.Livello * 10} punti esperienza");
                            eroe.AggiungiPuntiEsperienza(nemico.Livello * 10);
                        }
                        break;
                    case '2':
                        fineBattaglia = Fuga();
                        if(fineBattaglia)
                        {
                            Console.WriteLine($"Sei fuggito! Perdi {nemico.Livello * 5} punti esperienza");
                            eroe.AggiungiPuntiEsperienza(-nemico.Livello * 5);
                        }
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova!");
                        break;
                }

            } while (choice == 1 || choice == 2);

            return fineBattaglia;
        }

        private static bool Fuga()
        {
            Random random = new Random();
            return random.Next(2) == 1;
        }

        private static bool Attacco(Eroe eroe, Mostro nemico)
        {
            Arma arma = mainBL.GetArmaById(eroe.ArmaId);
            int puntiDanno = arma.PuntiDanno;
            Console.WriteLine($"L'eroe infligge un danno di {puntiDanno}");
            nemico.PuntiVita -= puntiDanno;
            Console.WriteLine($"Punti vita rimanenti del mostro dopo l'attacco: {(nemico.PuntiVita < 0 ? 0 : nemico.PuntiVita)}");
            Console.ResetColor();
            return nemico.PuntiVita <= 0;

        }

        private static void MenuAdmin(Utente utente)
        {
            char choice;

            do
            {
                Console.WriteLine("[1] Gioca" +
                    "\n[2] Crea un nuovo eroe" +
                    "\n[3] Elimina un eroe" +
                    "\n[4] Crea mostro" +
                    "\n[5] Mostra classifica globale" +
                    "\n[Q] Esci");

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Gioca(utente);
                        break;
                    case '2':
                        CreaNuovoEroe(utente);
                        break;
                    case '3':
                        CancellaEroe(utente);
                        break;
                    case '4':
                        CreaNuovoMostro();
                        break;
                    case '5':
                        ClassificaGlobale();
                        break;
                    case 'Q':
                        return;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova!");
                        break;
                }

            } while (!(choice == 'Q'));


        }

        private static void ClassificaGlobale()
        {
            IEnumerable<Eroe> bestEroes = mainBL.GetClassificaEroi();
            IEnumerable<Utente> utenti = mainBL.GetUtenti();

            int i = 1;
            foreach (var e in bestEroes)
            {
                Utente utente = utenti.Where(u => u.Id == e.UtenteId).FirstOrDefault();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{i}° classificato: {e.NomeEroe} - Punti accumulati: {e.PuntiAccumulati} - Giocatore: {utente.NickName}\n");
                Console.ResetColor();
                i++;
            }
        }

        private static void CreaNuovoMostro()
        {
            Console.WriteLine("Inserire nome del mostro:");

            string nomeMostro = Console.ReadLine();

            Console.WriteLine("Scegli categoria mostro:");

            int i = 1;
            foreach (string categoria in Enum.GetNames(typeof(TipoMostroEnum)))
            {
                Console.WriteLine(i + " " + categoria);
                i++;
            }
            int category;

            while (!int.TryParse(Console.ReadLine(), out category) || category >= i)
            {
                Console.WriteLine("Inserisci un valore valido");
            }

            Console.WriteLine("Seleziona arma:");

            TipoMostroEnum tipoArma = (TipoMostroEnum)category;
            string arma = $"Arma{tipoArma}";
            IEnumerable<Arma> armi = mainBL.GetArmiByCategory(arma);
            StampaArmi(armi);

            int idArma;
            while (!int.TryParse(Console.ReadLine(), out idArma) || !armi.Where(a => a.Id == idArma).Any())
            {
                Console.WriteLine("Inserisci un valore valido");
            }

            Console.WriteLine("Seleziona livello:");
            int level;

            while (!int.TryParse(Console.ReadLine(), out level) || (level < 1 && level > 5))
            {
                Console.WriteLine("Inserisci un valore valido compreso fra 1 e 5");
            }

            Mostro mostro = new Mostro();

            mostro.NomeMostro = nomeMostro;
            mostro.TipoMostro = (TipoMostroEnum)category;
            mostro.IdArma = idArma;

            bool verify = mainBL.AddNewMostro(mostro);

            if (verify)
                Console.WriteLine("Mostro inserito con successo");
        }
    }
}
