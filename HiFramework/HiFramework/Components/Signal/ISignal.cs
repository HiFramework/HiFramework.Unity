//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface ISignal
    {
        void Regist(Action handler);
        void Dispatch();

        void UnRegist();
        void UnRegist(Action handler);
    }

    public interface ISignal<T>
    {
        void Regist(Action<T> handler);
        void Dispatch(T args);

        void UnRegist();
        void UnRegist(Action<T> handler);
    }

    public interface ISignal<T, U>
    {
        void Regist(Action<T, U> handler);
        void Dispatch(T t, U u);
        void UnRegist();
        void UnRegist(Action<T, U> handler);
    }
    public interface ISignal<T, U, V>
    {
        void Regist(Action<T, U, V> handler);
        void Dispatch(T t, U u, V v);
        void UnRegist();
        void UnRegist(Action<T, U, V> handler);
    }
    public interface ISignal<T, U, V, W>
    {
        void Regist(Action<T, U, V, W> handler);
        void Dispatch(T t, U u, V v, W w);
        void UnRegist();
        void UnRegist(Action<T, U, V, W> handler);
    }
}
