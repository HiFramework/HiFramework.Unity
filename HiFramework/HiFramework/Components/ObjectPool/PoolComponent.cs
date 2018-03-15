/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    internal class PoolComponent : Component, IPoolComponent
    {
        List<object> _pools = new List<object>();
        public PoolComponent(IContainer iContainer) : base(iContainer)
        {
        }
        public void AddPool<T>(IPool<T> iPool)
        {
            Assert.IsFalse(_pools.Contains(iPool));
            _pools.Add(iPool);
        }

        public void RemovePool<T>(IPool<T> iPool)
        {
            Assert.IsTrue(_pools.Contains(iPool));
            _pools.Remove(iPool);
        }

        public override void OnInit()
        {
        }

        public override void OnClose()
        {
        }
    }
}
