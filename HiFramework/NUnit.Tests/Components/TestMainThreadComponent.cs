using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests.Components
{
    [TestFixture]
    public class TestMainThreadComponent
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");

            string ss = "this run on thread";
            var c = Center.Get<MainThreadComponent>();
            c.RunOnMainThread(x =>
            {
                string s = "this run on main thread";
            },null);
        }
    }
}
