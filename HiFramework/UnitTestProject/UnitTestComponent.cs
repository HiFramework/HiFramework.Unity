using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestComponent
    {
        [TestMethod]
        public void TestComponent()
        {
            Framework.Init();

            var c = Center.Get<Component>();

            Assert.IsNotNull(c);

            Console.WriteLine(c.x);

        }

        public class Component : HiFramework.IComponet
        {
            public int x = 10;
            public void Regist()
            {
                Console.WriteLine("regist");
            }

            public void UnRegist()
            {
                throw new NotImplementedException();
            }
        }
    }
}
