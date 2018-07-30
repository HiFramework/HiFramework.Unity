/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    internal class PoolManagerComponent : Component
    {
        /// <summary>
        /// 对象池集合
        /// </summary>
        private Dictionary<string, IPool> pools = new Dictionary<string, IPool>();

        /// <summary>
        /// 讲对象池添加到管理类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        public void AddPool<T>(string key, IPool<T> iPool)
        {
            pools.Add(key, iPool);
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IPool<T> GetPool<T>(string key)
        {
            var value = pools[key];
            return (IPool<T>)value;
        }

        /// <summary>
        /// 删除对象池,并销毁池内对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        public void RemovePool<T>(string key)
        {
            var value = GetPool<T>(key);
            value.Dispose();
            pools.Remove(key);
        }
    }
}
