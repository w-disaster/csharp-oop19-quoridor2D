using csharp_oop19_quoridor2D.BecciAlessandro;
using NUnit.Framework;

namespace UnitTest1.BecciAlessandro
{
    public class LoadTest
    {
        private LoadBarriers load;

        public LoadTest()
        {
            load = new LoadBarriers();
        }

        [Test]
        public void LoadBarrierTest()
        {
            Assert.IsTrue(load.Load());
        }
    }
}