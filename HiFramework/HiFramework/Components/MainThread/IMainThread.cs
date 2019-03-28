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
    }
}
