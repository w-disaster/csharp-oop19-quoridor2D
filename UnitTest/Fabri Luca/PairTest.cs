using System;
using NUnit.Framework;
using csharp_oop19_quoridor2D.Fabri_Luca;

namespace UnitTest.Fabri_Luca
{
    [TestFixture]
    public class PairTest
    {
        private Pair<int, int> pair1 = new Pair<int, int>(1, 2);
        private Pair<int, int> pair2 = new Pair<int, int>(1, 2);

        [Test]
        public void Test1()
        {
            Assert.True(pair1.Equals(pair2));
        }
    }
}