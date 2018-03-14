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
