using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestComponentThird
    {
        public static bool IsTrue;

        [TestMethod]
        public void TestComponentThird()
        {
            Framework.Init();

            IComponetLogic c = Center.Get<Component>();
            Assert.IsNotNull(c);
            c.Log();
            Assert.IsTrue(IsTrue);
        }

        public class Component : IComponet, IComponetLogic
        {
            private ComponentThrid _componentThrid;
            public void Regist()
            {
                _componentThrid = new ComponentThrid();
            }

            public void UnRegist()
            {
                throw new NotImplementedException();
            }

            public void Log()
            {
                _componentThrid.Log();
            }
        }

        public interface IComponetLogic//自定义第三方逻辑开放接口
        {
            void Log();
        }
        public class ComponentThrid//第三方逻辑
        {
            public void Log()
            {
                UnitTestComponentThird.IsTrue = true;
            }
        }
    }
}
