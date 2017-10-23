using NUnit.Framework;
using System;

namespace NUnit.Tests
{
    [SetUpFixture]
    public class TestMain
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            HiFramework.Framework.Init();

            int i = 0;
            while (i < 10000)
            {
                i++;
                HiFramework.Framework.Tick();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // TODO: Add code here that is run after
            //  all tests in the assembly have been run
        }
    }
}