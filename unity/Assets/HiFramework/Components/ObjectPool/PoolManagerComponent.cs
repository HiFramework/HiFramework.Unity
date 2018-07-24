/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    internal class PoolManagerComponent : Component, IPoolManagerComponent
    {
        /// <summary>
        /// 对象池集合
        /// </summary>
        private Dictionary<string, PoolBase> pools = new Dictionary<string, PoolBase>();

        /// <summary>
        /// 讲对象池添加到管理类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        public void AddPool<T>(string key, IPool<T> iPool)
        {
          //pools.Add();
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetPool<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除对象池,并销毁池内对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        public void RemovePool(string key)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除对象池,并销毁池内对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pool"></param>
        public void RemovePool<T>(IPool<T> pool)
        {
            throw new System.NotImplementedException();
        }
    }
}
