using System;
using csharp_oop19_quoridor2D;
using csharp_oop19_quoridor2D.Fabri_Luca;
using csharp_oop19_quoridor2D.Fabri_Luca.RoundBarriers;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void PairTest()
        {
            Pair<int, int> p1 = new Pair<int, int>(1, 2);
            Pair<int, int> p2 = new Pair<int, int>(1, 2);
            Assert.True(p1.Equals(p2));
        }

        [Test]
        public void BarrierTest()
        {
            IBarrier b1 = new BarrierImpl(new Coordinate(1, 2), BarrierOrientation.Horizontal, BarrierPiece.Head);
            IBarrier b2 = new BarrierImpl(new Coordinate(2, 2), BarrierOrientation.Vertical, BarrierPiece.Head);
            Assert.False(b1.Equals(b2));
        }
    }
}