using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Entities
{
    public class Eroe
    {
        public int Id { get; set; }
        public int UtenteId { get; set; }
        public string NomeEroe { get; set; }
        public TipoEroeEnum TipoEroe { get; set; }
        public int ArmaId { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int PuntiAccumulati { get; set; }

        public void AggiungiPuntiEsperienza(int puntiAccumulati)
        {
            PuntiAccumulati += puntiAccumulati;

            if(Livello < (PuntiAccumulati/30) + 1)
            {
                if (puntiAccumulati > 120)
                {
                    Livello = 5;
                    PuntiVita = 120;
                }
                else
                {
                    LevelUpPuntiAccumulati();
                    PuntiAccumulati = (Livello - 1) * 30;
                }
            }
        }
        public void LevelUpPuntiAccumulati()
        {
            Livello = (PuntiAccumulati / 30) + 1;
            PuntiVita = Livello * 20;
        }

        public override string ToString()
        {
            return $"ID: {Id}, " +
                $"UtenteID: {UtenteId}, " +
                $"Nome eroe: {NomeEroe}, " +
                $"Categoria eroe: {TipoEroe}, " +
                $"ArmaID: {ArmaId}, " +
                $"Livello: {Livello}, " +
                $"Punti vita: {PuntiVita}, " +
                $"Punti accumulati: {PuntiAccumulati}\n";
        }
    }

    public enum TipoEroeEnum
    {
        Guerriero = 1,
        Mago = 2
    }
}
