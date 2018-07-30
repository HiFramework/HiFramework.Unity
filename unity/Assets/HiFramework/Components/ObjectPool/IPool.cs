/***************************************************************
 * Description: 对象池基类接口
 * 可以创建多个不同的对象池，存储不同的数据类型
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPool
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPool<T> : IPool, IDisposable
    {
        /// <summary>
        /// 对象池内对象数量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="args"></param>
        void Reclaim(T args);
    }
}