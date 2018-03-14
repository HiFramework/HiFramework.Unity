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
    public class TestInject
    {
        [Test]
        public void TestMethod()
        {
            Test test = new Test();

            IBinder i = Center.Get<BinderComponent>();

            var test1 = new Test1();
            i.Bind<ITest1>().To(test1);
            i.Inject(test);
            Assert.IsNotNull(test.test1);

            //// TODO: Add your test code here
            //Assert.Pass("Your first passing test");
        }

        class Test
        {
            [Inject]
            public ITest1 test1;
        }


        interface ITest1
        {
            
        }
        class Test1
        {

        }

        class Test2
        {

        }
    }
}
