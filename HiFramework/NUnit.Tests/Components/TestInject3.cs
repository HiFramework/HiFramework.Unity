using HiFramework;
using NUnit.Framework;

/// <summary>
/// 接口绑定类型
/// </summary>
namespace NUnit.Tests.Components
{
    [TestFixture]
    public class TestInject3
    {
        [Test]
        public void TestMethod()
        {
            Test test = new Test();

            IBinder i = Center.Get<BinderComponent>();
            i.Bind<ITest>().To<Test1>();
            i.SetUp();

            i.Inject(test);
            Assert.IsTrue(test.test1.GetType().Name == "Test1");

            //// TODO: Add your test code here
            //Assert.Pass("Your first passing test");
        }

        class Test
        {
            [Inject]
            public ITest test1;
        }


        interface ITest
        {

        }
        class Test1 : ITest
        {

        }
    }
}
