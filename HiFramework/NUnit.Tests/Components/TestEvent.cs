using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestEvent
    {
        [Test]
        public void TestMethod()
        {
            IEvent iEvent = Center.Get<EventComponent>();
            iEvent.Regist("key", Handler);
            iEvent.Dispatch("key", 1, "hello");

        }

        void Handler(object[] args)
        {
            var t = (int)args[0];
            var tt = (string)args[1];

            Assert.IsTrue(t == 1);
            Assert.IsTrue(tt == "hello");
        }
    }
}
