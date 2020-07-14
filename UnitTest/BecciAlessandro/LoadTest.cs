using csharp_oop19_quoridor2D.BecciAlessandro;
using NUnit.Framework;

namespace UnitTest1.BecciAlessandro
{
    public class LoadTest
    {
        private LoadBarriers load;
        private SaveBarriers save;

        public LoadTest()
        {
            load = new LoadBarriers();
            save = new SaveBarriers();
        }

        [Test]
        public void LoadBarrierTest()
        {
            Assert.IsTrue(save.Save());
            Assert.IsTrue(load.Load());
        }
    }
}