//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;
namespace HiFramework
{
    /// <summary>
    /// 表现层控制逻辑
    /// </summary>
    public interface IView : ITick
    {
        /// <summary>
        /// bind this view to its controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Bind<T>() where T : IController, new();
    }
}