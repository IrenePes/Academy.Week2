using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Game.Core.Entities
{
    public class Arma
    {
        public int Id { get; set; }
        public string NomeArma { get; set; }
        public int PuntiDanno { get; set; }
        public CategoriaArmaEnum CategoriaArma { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, " +
                $"Nome arma: {NomeArma}, " +
                $"Punti danno: {PuntiDanno}, " +
                $"Categoria arma: {CategoriaArma}\n";
        }

    }

    public enum CategoriaArmaEnum
    {
        ArmaGuerriero = 1,
        ArmaMago = 2,
        ArmaCultista = 3,
        ArmaOrco = 4,
        ArmaSignoreDelMale = 5 
    }
}
