/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    internal class PoolComponent : Component
    {
        private List<object> pools = new List<object>();

        public void AddPool<T>(IPool<T> iPool)
        {
            AssertThat.IsFalse(pools.Contains(iPool));
            pools.Add(iPool);
        }

        public void RemovePool<T>(IPool<T> iPool)
        {
            AssertThat.IsTrue(pools.Contains(iPool));
            pools.Remove(iPool);
        }
    }
}
