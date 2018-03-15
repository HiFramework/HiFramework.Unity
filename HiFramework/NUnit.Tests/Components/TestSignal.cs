using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests.Components
{
    [TestFixture]
    public class TestSignal
    {
        [Test]
        public void TestMethod()
        {
            Signal noparam = new Signal();
            noparam.Regist(Hanlder);
            noparam.Dispatch();

            Signal<int, string> withParam = new Signal<int, string>();
            withParam.Regist(HandlerWithParam);
            withParam.Dispatch(1, "hello");

        }
        void Hanlder()
        {
            string log = "execute";
        }
        void HandlerWithParam(int x, string y)
        {
            string log = "execute" + x + y;
        }
    }
}
