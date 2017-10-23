using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestSignal
    {
        private int _count;
        [Test]
        public void TestRegistDispatch()
        {
            _count = 0;
            ISignal signal = Center.Get<SignalComponent>();
            signal.Regist("key", TestMethod1);
            signal.Regist("key", TestMethod2);
            signal.Dispatch("key");
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
