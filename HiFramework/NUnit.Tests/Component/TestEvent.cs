using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestEvent
    {
        private int _count;
        [Test]
        public void TestRegistDispatch()
        {
            _count = 0;
            IEvent @event = Center.Get<EventComponent>();
            @event.Regist("key", TestMethod1);
            @event.Regist("key", TestMethod2);
            @event.Dispatch("key");
            Assert.IsTrue(_count == 2);
        }

        void TestMethod1(object obj)
        {
            _count++;
        }

        void TestMethod2(object obj)
        {
            _count++;
        }
    }
}
