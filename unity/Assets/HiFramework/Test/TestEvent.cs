using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using HiFramework;
using Assert = NUnit.Framework.Assert;

public class TestEvent
{

    [Test]
    [PrebuildSetup(typeof(TestMain))]
    public void TestSimplePasses()
    {
        // Use the Assert class to test conditions.
        var @event = Center.Get<EventComponent>();
        @event.Regist("key", (x) =>
        {
            int args1 = (int)x[0];
            int args2 = (int)x[1];
            Assert.AreEqual(args1, 10);
            Assert.AreEqual(args2, 20);
        });
        @event.Dispatch("key", 10, 20);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
