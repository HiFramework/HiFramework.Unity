using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;

namespace NUnit.Tests.Component.Inject
{
    [TestFixture]
    public class TestInject2
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            IBinder i = Center.Get<BinderComponent>();
            Test1 t = new Test1();
            i.Bind<ITest>().To(t).AsName("test1");
            Test2 tt = new Test2();
            i.Bind<ITest>().To(tt).AsName("test2");
            i.SetUp();

            Test3 ttt= new Test3();
            i.Inject(ttt);
            Assert.IsTrue(((Test1)ttt.test1).x==10);
            Assert.IsTrue(((Test2)ttt.test1).x==20);
        }


        public interface ITest
        {
            
        }

        public class Test1 : ITest
        {
            public int x = 10;
        }

        public class Test2 : ITest
        {
            public int x = 20;
        }

        public class Test3
        {
            [Inject("test1")]
            public ITest test1;
            [Inject("test2")]
            public ITest test2;
        }
    }
}
