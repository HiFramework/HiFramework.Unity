using System;

namespace HiFramework.Component.MainThread
{
    public interface IMainThread
    {
        void RunOnMainThread(Action<object> action, object obj);

        void RunOnApplicationQuit(Action action);

        void Quit();

    }
}
