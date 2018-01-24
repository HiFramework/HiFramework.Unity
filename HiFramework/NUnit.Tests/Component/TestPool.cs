using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFramework;
using UnityEngine;
namespace NUnit.Tests.Component
{
    [TestFixture]
    public class TestPool
    {
        [Test]
        public void TestMethod()
        {
            IPoolComponent iPoolComponent = Center.Get<PoolComponent>();
            IPoolHandler<GameObject> t = new PoolHandler();
            IPool<GameObject> iPool = iPoolComponent.CreatePool(t);
            var go = iPool.Get();

            //finish use gameobject
            iPool.Reclaim(go);

            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }

    public class PoolHandler : IPoolHandler<GameObject>
    {
        public GameObject Create()
        {
            return Resources.Load("cube") as GameObject;
        }

        public void Destory(GameObject obj)
        {
            UnityEngine.Object.Destroy(obj);
        }

        public void InToPool(GameObject args)
        {
            args.SetActive(false);
        }

        public void OutFromPool(GameObject args)
        {
            args.SetActive(true);
        }
    }
}
