using System.Collections.Generic;
using csharp_oop19_quoridor2D.BecciAlessandro;
using csharp_oop19_quoridor2D.Fabri_Luca.Positioning;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;

namespace UnitTest1.BecciAlessandro
{
    public class SaveTest
    {
        private SaveBarriers saver;
        private RoundBarriers rb;
        
        public SaveTest()
        {
            saver = new SaveBarriers();
            rb = new RoundBarriers();
        }

        public void SaveBarriers()
        {
            IBarrier b1 = new Barrier(new Coordinate(0, RoundBarriers.BoardDimension / 2),
                BarrierOrientation.Horizontal, BarrierPiece.Head);
            IBarrier b2 = new Barrier(new Coordinate(1, RoundBarriers.BoardDimension / 2),
                BarrierOrientation.Horizontal, BarrierPiece.Tail);

            IList<IBarrier> barriers = new List<IBarrier>()
            {
                b1, b2
            };
            
            foreach (var barrier in barriers)
            {
                this.rb.Add(barrier);
            }
            
            saver.Save(rb);
            
        }
    }
}