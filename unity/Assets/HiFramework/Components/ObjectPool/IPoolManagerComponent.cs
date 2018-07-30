//****************************************************************************
// Description: 对象池管理组件
// Author: hiramtan@qq.com
//****************************************************************************

namespace HiFramework
{
    internal interface IPoolManagerComponent
    {
        /// <summary>
        /// 讲对象池添加到管理类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        void AddPool<T>(string key, IPool<T> iPool);

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        IPool<T> GetPool<T>(string key);

        /// <summary>
        /// 删除对象池,并销毁池内对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iPool"></param>
        void RemovePool(string key);
    }
}