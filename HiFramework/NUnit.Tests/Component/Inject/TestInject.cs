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
    public class TestInject
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");

            var i = Center.Get<IBinder>();
            var test = new Test();
            i.Bind<ITest>().To(test);
            var test1 = new Test1();
            i.Inject(test1);
            Assert.IsTrue(((Test)test1.ITest).x==10);
        }



        public interface ITest
        {

        }
        public class Test:ITest
        {
            public int x = 10;
        }

        public class Test1
        {
            [Inject]
            public ITest ITest;
        }
    }



}
