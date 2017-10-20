using System;
using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class UnitTestComponent
    {
        public static bool _isTrue;
        [Test]
        public void TestComponent()
        {
            HiFramework.Framework.Init();

            var c = Center.Get<Component>();
            Assert.IsNotNull(c);
            Assert.IsTrue(_isTrue);
        }
        public class Component : HiFramework.IComponent
        {
            public int x = 10;
            public void OnRegist()
            {
                UnitTestComponent._isTrue = true;
            }

            public void OnUnRegist()
            {
                throw new NotImplementedException();
            }
        }
    }
}
