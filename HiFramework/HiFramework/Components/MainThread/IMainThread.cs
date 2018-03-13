//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface IMainThread
    {
        void RunOnMainThread(Action<object> action, object obj);

        void RunOnApplicationQuit(Action action);

        void Quit();

    }
}
