using System;
using System.Collections.Generic;
using csharp_oop19_quoridor2D.BecciAlessandro;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;
using csharp_oop19_quoridor2D.FabriLuca.RoundBarriers;
using NUnit.Framework;

namespace UnitTest1.BecciAlessandro
{
    public class SaveTest
    {
        private readonly SaveBarriers saver;
        private readonly RoundBarriers rb;
        private readonly LoadBarriers loader;

        public SaveTest()
        {
            saver = new SaveBarriers();
            rb = new RoundBarriers();
            loader = new LoadBarriers();
        }
        [Test]
        public void SaveLoadBarriersTest()
        {
            IBarrier b1 = new Barrier(new Coordinate(0, RoundBarriers.BOARD_DIMENSION / 2),
                BarrierOrientation.Horizontal, BarrierPiece.Head);
            IBarrier b2 = new Barrier(new Coordinate(1, RoundBarriers.BOARD_DIMENSION / 2),
                BarrierOrientation.Horizontal, BarrierPiece.Tail);

            IList<IBarrier> barriers = new List<IBarrier>()
            {
                b1, b2
            };

            foreach (var barrier in barriers)
            {
                this.rb.Add(barrier);
            }

            Assert.IsTrue(saver.Save(rb));
            Assert.IsTrue(loader.Load());
            Assert.IsTrue(loader.Barriers.Contains(b1));
            Assert.IsTrue(loader.Barriers.Contains(b2));
        }

        
    }
}