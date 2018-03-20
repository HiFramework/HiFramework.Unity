//****************************************************************************
// Description: 对象池管理组件
// Author: hiramtan@qq.com
//****************************************************************************

namespace HiFramework
{
    internal interface IPoolComponent
    {
        void AddPool<T>(IPool<T> iPool);

        void RemovePool<T>(IPool<T> iPool);
    }
}