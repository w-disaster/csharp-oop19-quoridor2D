using csharp_oop19_quoridor2D.DAmbrosioStefano;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.DAmbrosioStefano
{
    class PowerUpTest
    {
        private IPowerUp plusOneBarrierTest;
        private IPowerUp plusOneMoveTest;
        private IRoundPowerUps roundPowerUpTest;
        private List<PowerUp> powerUpList;

        public PowerUpTest()
        {
            this.plusOneBarrierTest = new PowerUp(Type.PlusOneBarrier);
            this.plusOneMoveTest = new PowerUp(Type.PlusOneMove);
            this.roundPowerUpTest = new RoundPowerUps();
            this.powerUpList = this.roundPowerUpTest.GetPowerUpsAsList();
        }

        [Test]
        public void Test()
        {
            // Check if powerUp type is correct
            Assert.AreEqual(Type.PlusOneBarrier, plusOneBarrierTest.Type);
            Assert.AreEqual(Type.PlusOneMove, plusOneMoveTest.Type);
            // Check the coordinates (powerUps can't spawn in the first two rows of each side)
            // Barrier PowerUp
            Assert.IsTrue(plusOneBarrierTest.Coordinate.First >= 0);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.First <= 8);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.Second > 1);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.Second < 7); 
            // Move PowerUp
            Assert.IsTrue(plusOneMoveTest.Coordinate.First >= 0);
            Assert.IsTrue(plusOneMoveTest.Coordinate.First <= 8);
            Assert.IsTrue(plusOneMoveTest.Coordinate.Second > 1);
            Assert.IsTrue(plusOneMoveTest.Coordinate.Second < 7);

            // Check if the list contains the right number of PowerUps
            Assert.AreEqual(powerUpList.Count, 6);
            // Check if any powerUp has the same coordinate
            Assert.IsTrue(powerUpList.GroupBy(x => x.Coordinate).Any(y => y.Count() > 1));
        }

    }
}
