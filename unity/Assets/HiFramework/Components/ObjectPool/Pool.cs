/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    public class Pool<T> : IPool<T>
    {
        private readonly IPoolHandler<T> poolHandler;
        private readonly Queue<T> objects = new Queue<T>();
        private readonly PoolComponent poolComponent;
        public Pool(IPoolHandler<T> poolHandler)
        {
            this.poolHandler = poolHandler;
            poolComponent = Center.Get<PoolComponent>();
            poolComponent.AddPool(this);
        }
        public void Destory()
        {
            while (objects.Count > 0)
            {
                var obj = objects.Dequeue();
                poolHandler.Destory(obj);
            }
            poolComponent.RemovePool(this);
        }
        public T Get()
        {
            T t = default(T);
            if (objects.Count > 0)
            {
                t = objects.Dequeue();
                poolHandler.OutFromPool(t);
            }
            else
            {
                t = poolHandler.Create();
            }
            return t;
        }
        public void Reclaim(T args)
        {
            poolHandler.InToPool(args);
            objects.Enqueue(args);
        }
    }
}
