using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;

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
