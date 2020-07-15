using System;
using NUnit.Framework;
using csharp_oop19_quoridor2D.CastellaniThomas;
using csharp_oop19_quoridor2D.FabriLuca.Positioning;
using csharp_oop19_quoridor2D.FabriLuca.RoundBarriers;

namespace UnitTest.CastellaniThomas
{
    public class BarrierPlacerTest
    {
        private IBarrierPlacer placer;

        public BarrierPlacerTest()
        {
            this.placer = new BarrierPlacer();
        }

        [Test]
        public void PlacerTest()
        {
            this.placer.PlaceBarrier(new Coordinate(0, 4), BarrierOrientation.Horizontal);
            Assert.False(this.placer.CheckPlacement(new Coordinate(0, 4), BarrierOrientation.Horizontal)); //not empty position
            Assert.False(this.placer.CheckPlacement(new Coordinate(0, 4), BarrierOrientation.Vertical));
            this.placer.PlaceBarrier(new Coordinate(2, 4), BarrierOrientation.Horizontal);
            this.placer.PlaceBarrier(new Coordinate(4, 4), BarrierOrientation.Horizontal);
            this.placer.PlaceBarrier(new Coordinate(6, 4), BarrierOrientation.Horizontal);
            Assert.False(this.placer.CheckPlacement(new Coordinate(8, 4), BarrierOrientation.Horizontal)); //edges
            Assert.False(this.placer.CheckPlacement(new Coordinate(0, 8), BarrierOrientation.Vertical));
            this.placer.PlaceBarrier(new Coordinate(6, 5), BarrierOrientation.Vertical);
            Assert.False(this.placer.CheckPlacement(new Coordinate(7, 6), BarrierOrientation.Horizontal)); //stall
            this.placer.PlaceBarrier(new Coordinate(0, 7), BarrierOrientation.Horizontal);
            this.placer.PlaceBarrier(new Coordinate(2, 7), BarrierOrientation.Horizontal);
            this.placer.PlaceBarrier(new Coordinate(4, 7), BarrierOrientation.Horizontal);
            this.placer.PlaceBarrier(new Coordinate(6, 7), BarrierOrientation.Horizontal);
            this.placer.PlaceBarrier(new Coordinate(0, 6), BarrierOrientation.Horizontal);
            Assert.False(this.placer.CheckPlacement(new Coordinate(0, 5), BarrierOrientation.Horizontal)); //not enough barriers
        }
    }
}