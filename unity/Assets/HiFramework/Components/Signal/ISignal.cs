//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;

namespace HiFramework
{
    public interface ISignal
    {
        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        void AddListener(Action action);

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        void RemoveListener(Action action);

        /// <summary>
        /// Fire the signal
        /// </summary>
        void Fire();
    }

    public interface ISignal<T>
    {
        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        void AddListener(Action<T> action);

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        void RemoveListener(Action<T> action);

        /// <summary>
        /// Fire the signal
        /// </summary>
        /// <param name="args"></param>
        void Fire(T args);
    }

    public interface ISignal<T1, T2>
    {
        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        void AddListener(Action<T1, T2> action);

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        void RemoveListener(Action<T1, T2> action);

        /// <summary>
        /// Fire the signal
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        void Fire(T1 t1, T2 t2);
    }

    public interface ISignal<T1, T2, T3>
    {
        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        void AddListener(Action<T1, T2, T3> action);

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        void RemoveListener(Action<T1, T2, T3> action);

        /// <summary>
        /// Fire the signal
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        void Fire(T1 t1, T2 t2, T3 t3);
    }

    public interface ISignal<T1, T2, T3, T4>
    {
        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        void AddListener(Action<T1, T2, T3, T4> action);

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        void RemoveListener(Action<T1, T2, T3, T4> action);

        /// <summary>
        /// Fire the signal
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <param name="t4"></param>
        void Fire(T1 t1, T2 t2, T3 t3, T4 t4);
    }
}
