using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Entities
{
    public class Mostro
    {
        public string NomeMostro { get; set; }
        public TipoMostroEnum TipoMostro { get; set; }
        public int IdArma { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }

        public override string ToString()
        {
            return $"Nome mostro: {NomeMostro}, " +
                $"Categoria mostro: {TipoMostro}, " +
                $"ArmaID: {IdArma}, " +
                $"Livello: {Livello}, " +
                $"Punti vita: {PuntiVita}\n";
        }
    }

    public enum TipoMostroEnum
    {
        Cultista = 1,
        Orco = 2,
        SignoreDelMale = 3
    }
}
