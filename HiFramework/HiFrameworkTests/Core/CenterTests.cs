using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiFramework.Tests
{
    [TestClass()]
    public class CenterTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var c = Center.Get<TickComponent>();
            Assert.IsNotNull(c);
            Assert.IsTrue(c is TickComponent);
        }

        [TestMethod()]
        public void IsExistTest()
        {
            var c = Center.Get<TickComponent>();
            var isTrue = Center.IsExist<TickComponent>();
            Assert.IsTrue(isTrue);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var c = Center.Get<TickComponent>();
            Center.Remove<TickComponent>();
        }
    }
}