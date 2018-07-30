/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Pool<T> : PoolBase, IPool<T>
    {
        /// <summary>
        /// 单个对象处理
        /// </summary>
        private IObjectHandler<T> objectHandler;

        /// <summary>
        /// 对象列表
        /// </summary>
        private Queue<T> objects = new Queue<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectHandler"></param>
        public Pool(IObjectHandler<T> objectHandler)
        {
            this.objectHandler = objectHandler;
        }

        /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
        public void Dispose()
        {
            while (objects.Count > 0)
            {
                var obj = objects.Dequeue();
                objectHandler.OnDestory(obj);
            }
            objectHandler = null;
        }

        /// <summary>
        /// 对象池内对象数量
        /// </summary>
        public int Count
        {
            get { return objects.Count; }
        }

        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            if (objects.Count > 0)
            {
                var obj = objects.Dequeue();
                objectHandler.OnGetFromPool(obj);
            }
            return objectHandler.OnCreate();
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="args"></param>
        public void Reclaim(T args)
        {
            objectHandler.OnInToPool(args);
            objects.Enqueue(args);
        }
    }
}