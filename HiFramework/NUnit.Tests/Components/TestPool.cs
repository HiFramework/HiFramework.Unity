using HiFramework;
using NUnit.Framework;
using UnityEngine;

namespace NUnit.Tests.Components
{
    [TestFixture]
    public class TestPool
    {
        [Test]
        public void TestMethod()
        {
            var pool = new Pool<GameObject>(new GameObjectHandler());
            var go = pool.Get();
            pool.Reclaim(go);
        }
        class GameObjectHandler : IPoolHandler<GameObject>
        {
            public GameObject Create()
            {
                return UnityEngine.Object.Instantiate(Resources.Load("")) as GameObject;
            }

            public void Destory(GameObject obj)
            {
                Destory(obj);
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
}
