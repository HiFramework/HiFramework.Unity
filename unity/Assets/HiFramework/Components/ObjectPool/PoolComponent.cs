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
        List<object> _pools = new List<object>();

        public void AddPool<T>(IPool<T> iPool)
        {
            HiAssert.IsFalse(_pools.Contains(iPool));
            _pools.Add(iPool);
        }

        public void RemovePool<T>(IPool<T> iPool)
        {
            HiAssert.IsTrue(_pools.Contains(iPool));
            _pools.Remove(iPool);
        }

        public override void OnCreated()
        {
        }

        public override void OnRemoved()
        {
        }
    }
}
