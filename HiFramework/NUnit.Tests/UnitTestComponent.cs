using System;
using HiFramework;
using NUnit.Framework;

namespace NUnit.Tests
{
    [TestFixture]
    public class UnitTestComponent
    {
        public static bool IsTrue;
        [Test]
        public void TestComponent()
        {
            HiFramework.Framework.Init();

            var c = Center.Get<Component>();
            Assert.IsNotNull(c);
            Assert.IsTrue(IsTrue);
        }
        public class Component : HiFramework.IComponent
        {
            public int X = 10;
            public void OnRegist()
            {
                UnitTestComponent.IsTrue = true;
            }

            public void OnUnRegist()
            {
                throw new NotImplementedException();
            }
        }
    }
}
