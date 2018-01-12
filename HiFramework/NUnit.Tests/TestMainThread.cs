using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestMainThread
    {
        [Test]
        public void TestMethodMainThread()
        {
            // TODO: Add your test code here
            bool isTrue = false;

            IMainThread iMainThread = Center.Get<MainThreadComponent>();

            iMainThread.RunOnMainThread((x) => { isTrue = true; }, null);


            int i = 0;

            while (i < 100)
            {
                i++;
                HiFramework.Framework.Tick();
            }

            Assert.IsTrue(isTrue);

            Assert.Pass("Your first passing test");

        }

        [Test]
        public void TestMethodApplicationQuit()
        {

            bool isTrue = false;

            IMainThread iMainThread = Center.Get<MainThreadComponent>();

            iMainThread.RunOnApplicationQuit(() => { isTrue = true; });


            iMainThread.Quit();

            Assert.IsTrue(isTrue);

        }
    }
}
