using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;
namespace NUnit.Tests
{
    [TestFixture]
    public class UnitTestMain
    {
        [Test]
        public void TestMain()
        {
            if (!NUnit.isInited)
            {
                NUnit.isInited = true;
                HiFramework.Framework.Init();
            }

            int i = 0;
            while (i < 10000)
            {
                i++;
                HiFramework.Framework.Tick();
            }
        }
    }
}
