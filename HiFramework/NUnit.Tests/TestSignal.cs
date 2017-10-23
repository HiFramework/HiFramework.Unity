using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;

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
            if (!NUnit.isInited)
            {
                NUnit.isInited = true;
                HiFramework.Framework.Init();
            }
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
