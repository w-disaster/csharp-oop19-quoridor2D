using System;
using csharp_oop19_quoridor2D.Fabri_Luca;

namespace csharp_oop19_quoridor2D.CastellaniThomas
{
    public interface IBarrierPlacer
    {
        void PlaceBarrier(); //devo aggiungere i parametri
    }

    public class BarrierPlacer : IBarrierPlacer
    {
        //attributo model
        //derivati di model se servono
        //Coordinate barriera
        //Orientamento barriera

        public BarrierPlacer()
        {
            //inizializzo attributi
        }

        public void PlaceBarrier() 
        {
            //implementazione piazzamento
        }

        //vari metodi privati di controllo
    }
}