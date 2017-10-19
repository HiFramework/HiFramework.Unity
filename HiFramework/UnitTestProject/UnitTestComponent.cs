using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestComponent
    {
        public static bool _isTrue;
        [TestMethod]
        public void TestComponent()
        {
            Framework.Init();

            var c = Center.Get<Component>();
            Assert.IsNotNull(c);
            Assert.IsTrue(_isTrue);
        }
        public class Component : HiFramework.IComponet
        {
            public int x = 10;
            public void Regist()
            {
                UnitTestComponent._isTrue = true;
            }

            public void UnRegist()
            {
                throw new NotImplementedException();
            }
        }
    }
}
