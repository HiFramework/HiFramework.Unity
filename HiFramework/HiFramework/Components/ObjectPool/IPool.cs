//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;

namespace HiFramework
{
    public interface IPool<T>
    {
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        T Get();
        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="args"></param>
        void Reclaim(T args);
        /// <summary>
        /// 卸载对象池所有对象
        /// </summary>
        void Destory();
    }
}