using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestAsyncCount
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            HiFramework.Framework.Init();
            bool isTrue = false;

            new AsyncCountTask((x) => { isTrue = true; }, 100);

            int i = 0;
            while (i < 10000)
            {
                i++;
                HiFramework.Framework.Tick();
            }

            Assert.IsTrue(isTrue);

            Assert.Pass("Your first passing test");
        }
    }
}
