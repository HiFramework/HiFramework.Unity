using HiFramework;
using NUnit.Framework;

/// <summary>
/// 接口绑定单一对象
/// </summary>
namespace NUnit.Tests.Components
{
    [TestFixture]
    public class TestInject1
    {
        [Test]
        public void TestMethod()
        {
            Test test = new Test();

            IBinder i = Center.Get<BinderComponent>();
            var test1 = new Test1();
            i.Bind<ITest>().To(test1);
            i.SetUp();

            i.Inject(test);
            Assert.IsTrue(test.test1.GetType().Name=="Test1");

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
