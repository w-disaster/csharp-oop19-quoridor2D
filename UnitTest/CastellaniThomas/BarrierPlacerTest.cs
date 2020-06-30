using System;
using NUnit.Framework;
using csharp_oop19_quoridor2D.CastellaniThomas;

namespace UnitTest.CastellaniThomas
{
    public class BarrierPlacerTest
    {
        private IBarrierPlacer Placer;

        public BarrierPlacerTest()
        {
            this.Placer = new BarrierPlacer();
        }

        [Test]
        public void PlacerTest()
        {
            Assert.True(true);
        }
    }
}