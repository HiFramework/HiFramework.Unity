using NUnit.Framework;
using HiFramework;

/// <summary>
/// 接口绑定多对象
/// </summary>
namespace NUnit.Tests.Components
{
    [TestFixture]
    public class TestInject2
    {
        [Test]
        public void TestMethod()
        {
            Test test = new Test();

            IBinder i = Center.Get<BinderComponent>();
            var test1 = new Test1();
            i.Bind<ITest>().To(test1).AsName("test1");
            var test2 = new Test2();
            i.Bind<ITest>().To(test2).AsName("test2");
            i.SetUp();

            i.Inject(test);
            Assert.IsTrue(test.test1.GetType().Name == "Test1");
            Assert.IsTrue(test.test2.GetType().Name == "Test2");
        }
        class Test
        {
            [Inject("test1")]
            public ITest test1;

            [Inject("test2")]
            public ITest test2;
        }


        interface ITest
        {

        }
        class Test1 : ITest
        {

        }

        class Test2 : ITest
        {

        }
    }
}
