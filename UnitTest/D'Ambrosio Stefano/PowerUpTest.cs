using csharp_oop19_quoridor2D.D_Ambrosio_Stefano;
using NUnit.Framework;

namespace UnitTest.D_Ambrosio_Stefano
{
    class PowerUpTest
    {
        private IPowerUp plusOneBarrierTest;
        private IPowerUp plusOneMoveTest;

        public PowerUpTest()
        {
            this.plusOneBarrierTest = new PowerUp(Type.PlusOneBarrier);
            this.plusOneMoveTest = new PowerUp(Type.PlusOneMove);
        }

        [Test]
        public void Test()
        {
            // Check if powerUp type is correct
            Assert.AreEqual(Type.PlusOneBarrier, plusOneBarrierTest.Type);
            Assert.AreEqual(Type.PlusOneMove, plusOneMoveTest.Type);
            // Check the coordinates (powerUps can't spawn in the first two rows of each side)
            Assert.IsTrue(plusOneBarrierTest.Coordinate.First >= 0);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.First <= 8);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.Second > 1);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.Second < 7);     
        }

    }
}
