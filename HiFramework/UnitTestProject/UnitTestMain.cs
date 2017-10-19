using HiFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestMain
    {
        [TestMethod]
        public void TestMethod1()
        {
            Framework.Init();

            int i = 0;
            while (i < 10000)
            {
                i++;
                Framework.Tick();
            }
        }
    }
}
