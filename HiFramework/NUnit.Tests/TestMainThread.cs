using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;
using HiFramework.Component.MainThread;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestMainThread
    {
        [Test]
        public void TestMethodMainThread()
        {
            // TODO: Add your test code here

            if (!NUnit.isInited)
            {
                NUnit.isInited = true;
                HiFramework.Framework.Init();
            }

            bool isTrue = false;

            IMainThread iMainThread = Center.Get<MainThreadComponent>();

            iMainThread.RunOnMainThread((x) => { isTrue = true; }, null);


            int i = 0;

            while (i < 100)
            {
                i++;
                HiFramework.Framework.Tick();
            }

            Assert.IsTrue(isTrue);

            Assert.Pass("Your first passing test");

        }

        [Test]
        public void TestMethodApplicationQuit()
        {
            if (!NUnit.isInited)
            {
                NUnit.isInited = true;
                HiFramework.Framework.Init();
            }

            bool isTrue = false;

            IMainThread iMainThread = Center.Get<MainThreadComponent>();

            iMainThread.RunOnApplicationQuit(() => { isTrue = true; });


            iMainThread.Quit();

            Assert.IsTrue(isTrue);

        }
    }
}
