//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface IPoolHandler<T>
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <returns></returns>
        T Create();
        /// <summary>
        /// 卸载对象
        /// </summary>
        /// <param name="obj"></param>
        void Destory(T obj);
        /// <summary>
        /// 添加到对象池,比如隐藏
        /// </summary>
        void InToPool(T args);
        /// <summary>
        /// 对象池取出,比如显示设置坐标
        /// </summary>
        void OutFromPool(T args);
    }
}
