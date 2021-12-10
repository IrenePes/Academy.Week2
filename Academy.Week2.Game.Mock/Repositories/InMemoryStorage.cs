using Academy.Week2.Game.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Mock.Repositories
{
    public class InMemoryStorage
    {
        public static List<Arma> Armi = new List<Arma>()
        { 
            new Arma(){Id = 1, NomeArma = "Alabarda", CategoriaArma = CategoriaArmaEnum.ArmaGuerriero, PuntiDanno = 15},
            new Arma(){Id = 2, NomeArma = "Ascia", CategoriaArma = CategoriaArmaEnum.ArmaGuerriero, PuntiDanno = 8},
            new Arma(){Id = 3, NomeArma = "Mazza", CategoriaArma = CategoriaArmaEnum.ArmaGuerriero, PuntiDanno = 5},
            new Arma(){Id = 4, NomeArma = "Spada", CategoriaArma = CategoriaArmaEnum.ArmaGuerriero, PuntiDanno = 10},
            new Arma(){Id = 5, NomeArma = "Spadone", CategoriaArma = CategoriaArmaEnum.ArmaGuerriero, PuntiDanno = 15},

            new Arma(){Id = 6, NomeArma = "Arco e frecce", CategoriaArma = CategoriaArmaEnum.ArmaMago, PuntiDanno = 8},
            new Arma(){Id = 7, NomeArma = "Bacchetta", CategoriaArma = CategoriaArmaEnum.ArmaMago, PuntiDanno = 5},
            new Arma(){Id = 8, NomeArma = "Bastone magico", CategoriaArma = CategoriaArmaEnum.ArmaMago, PuntiDanno = 10},
            new Arma(){Id = 9, NomeArma = "Onda d'urto", CategoriaArma = CategoriaArmaEnum.ArmaMago, PuntiDanno = 15},
            new Arma(){Id = 10, NomeArma = "Pugnale", CategoriaArma = CategoriaArmaEnum.ArmaMago, PuntiDanno = 5},

            new Arma(){Id = 11, NomeArma = "Discorso noioso", CategoriaArma = CategoriaArmaEnum.ArmaCultista, PuntiDanno = 4},
            new Arma(){Id = 12, NomeArma = "Farneticazione", CategoriaArma = CategoriaArmaEnum.ArmaCultista, PuntiDanno = 7},
            new Arma(){Id = 13, NomeArma = "Imprecazione", CategoriaArma = CategoriaArmaEnum.ArmaCultista, PuntiDanno = 5},
            new Arma(){Id = 14, NomeArma = "Magia nera", CategoriaArma = CategoriaArmaEnum.ArmaCultista, PuntiDanno = 3},

            new Arma(){Id = 15, NomeArma = "Arco", CategoriaArma = CategoriaArmaEnum.ArmaOrco, PuntiDanno = 7},
            new Arma(){Id = 16, NomeArma = "Clava", CategoriaArma = CategoriaArmaEnum.ArmaOrco, PuntiDanno = 5},
            new Arma(){Id = 17, NomeArma = "Spada rotta", CategoriaArma = CategoriaArmaEnum.ArmaOrco, PuntiDanno = 3},
            new Arma(){Id = 18, NomeArma = "Mazza chiodata", CategoriaArma = CategoriaArmaEnum.ArmaOrco, PuntiDanno = 10},

            new Arma(){Id = 19, NomeArma = "Alabarda del drago", CategoriaArma = CategoriaArmaEnum.ArmaSignoreDelMale, PuntiDanno = 30},
            new Arma(){Id = 20, NomeArma = "Divinazione", CategoriaArma = CategoriaArmaEnum.ArmaSignoreDelMale, PuntiDanno = 15},
            new Arma(){Id = 21, NomeArma = "Fulmine", CategoriaArma = CategoriaArmaEnum.ArmaSignoreDelMale, PuntiDanno = 10},
            new Arma(){Id = 22, NomeArma = "Fulmine celeste", CategoriaArma = CategoriaArmaEnum.ArmaSignoreDelMale, PuntiDanno = 15},
            new Arma(){Id = 23, NomeArma = "Tempesta", CategoriaArma = CategoriaArmaEnum.ArmaSignoreDelMale, PuntiDanno = 8},
            new Arma(){Id = 24, NomeArma = "Tempesta oscura", CategoriaArma = CategoriaArmaEnum.ArmaSignoreDelMale, PuntiDanno = 15}

        };

        public static List<Mostro> Mostri = new List<Mostro>()
        {
            new Mostro(){NomeMostro = "Shrek", Livello = 3, PuntiVita = 60, IdArma = 16, TipoMostro = TipoMostroEnum.Orco},
            new Mostro(){NomeMostro = "Oscar", Livello = 1, PuntiVita = 20, IdArma = 23, TipoMostro = TipoMostroEnum.SignoreDelMale},
            new Mostro(){NomeMostro = "Tesla", Livello = 2, PuntiVita = 40, IdArma = 11, TipoMostro = TipoMostroEnum.Cultista},
            new Mostro(){NomeMostro = "Volt", Livello = 4, PuntiVita = 80, IdArma = 13, TipoMostro = TipoMostroEnum.Cultista},
            new Mostro(){NomeMostro = "Romits", Livello = 5, PuntiVita = 100, IdArma = 20, TipoMostro = TipoMostroEnum.SignoreDelMale},
            new Mostro(){NomeMostro = "Olly", Livello = 1, PuntiVita = 20, IdArma = 18, TipoMostro = TipoMostroEnum.Orco}
        };

        public static List<Utente> Utenti = new List<Utente>()
        {
            new Utente(){Id = 1, NickName = "RosaPink", Password = "Rosa.18", IsAdmin = false},
            new Utente(){Id = 2, NickName = "LeoTopPlayer", Password = "OscarLeo", IsAdmin = true}
        };

        public static List<Eroe> Eroi = new List<Eroe>()
        {
            new Eroe(){Id = 1, UtenteId = 1, NomeEroe = "Irene", TipoEroe = TipoEroeEnum.Mago, ArmaId = 9, Livello = 2, PuntiVita = 40, PuntiAccumulati = 30},
            new Eroe(){Id = 2, UtenteId = 1, NomeEroe = "Antonino", TipoEroe = TipoEroeEnum.Guerriero, ArmaId = 2, Livello = 1, PuntiVita = 20, PuntiAccumulati = 15},
            new Eroe(){Id = 3, UtenteId = 2, NomeEroe = "Valentina", TipoEroe = TipoEroeEnum.Mago, ArmaId = 9, Livello = 4, PuntiVita = 80, PuntiAccumulati = 95},
            new Eroe(){Id = 4, UtenteId = 2, NomeEroe = "Luca", TipoEroe = TipoEroeEnum.Guerriero, ArmaId = 5, Livello = 5, PuntiVita = 100, PuntiAccumulati = 110}
            
        };
    }
}
