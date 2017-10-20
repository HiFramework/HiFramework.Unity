using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    [TestFixture]
    public class UnitTestComponentThird
    {
      
        public static bool IsTrue;

        [Test]
        public void TestComponentThird()
        {
          HiFramework.  Framework.Init();

            IComponetLogic c = HiFramework.Center.Get<Component>();
            Assert.IsNotNull(c);
            c.Log();
            Assert.IsTrue(IsTrue);
        }

        public class Component : HiFramework.IComponent, IComponetLogic
        {
            private ComponentThrid _componentThrid;
            public void OnRegist()
            {
                _componentThrid = new ComponentThrid();
            }

            public void OnUnRegist()
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
