//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;

namespace HiFramework
{
    public interface IPool<T>
    {
        T Get();
        void Reclaim(T args);
        /// <summary>
        /// 卸载对象池所有对象
        /// </summary>
        void Destory();
    }
}