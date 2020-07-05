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
            Assert.AreEqual(Type.PlusOneBarrier, plusOneBarrierTest.Type);
            Assert.AreEqual(Type.PlusOneMove, plusOneMoveTest.Type);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.Second > 1);
            Assert.IsTrue(plusOneBarrierTest.Coordinate.Second < 8);
        }

    }
}
