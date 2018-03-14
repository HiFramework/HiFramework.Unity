//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface IMainThread
    {
        /// <summary>
        /// 抛到主线程执行
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        void RunOnMainThread(Action<object> action, object obj);

        /// <summary>
        /// Quit接口被调用时执行
        /// </summary>
        /// <param name="action"></param>
        void RunOnApplicationQuit(Action action);

        /// <summary>
        /// Quit接口
        /// </summary>
        void Quit();

    }
}
