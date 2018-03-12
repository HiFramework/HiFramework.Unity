using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;

namespace NUnit.Tests.Component
{
    [TestFixture]
    public class TestSignal
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");

            ISignal test = new Signal();
            test.Regist(Test);

            ISignal<string> test1 = new Signal<string>();
            test1.Regist(Test1);

            ISignal<int> test2 = new Signal<int>();
            test2.Regist(Test2);

            ISignal<int, float, string> test3 = new Signal<int, float, string>();
            test3.Regist(Test3);



            test.Dispatch();
            test1.Dispatch("s");
            test2.Dispatch(1);
            test3.Dispatch(1, 2.0f, "s");
        }

        void Test()
        {

        }

        void Test1(string args)
        {

        }

        void Test2(int args)
        {

        }

        void Test3(int i, float f, string s)
        {

        }
    }
}
