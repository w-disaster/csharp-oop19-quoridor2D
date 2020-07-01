using NUnit.Framework;

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