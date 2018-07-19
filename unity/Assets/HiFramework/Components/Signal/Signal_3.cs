/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{

    public class Signal<T1, T2, T3> : SignalBase, ISignal<T1, T2, T3>
    {
        private event Action<T1, T2, T3> OnEvent;
        /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
        public override void Dispose()
        {
            OnEvent = null;
        }

        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            OnEvent += action;
        }

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        public void RemoveListener(Action<T1, T2, T3> action)
        {
            OnEvent -= action;
        }

        /// <summary>
        /// Fire the signal
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        public void Fire(T1 t1, T2 t2, T3 t3)
        {
            OnEvent(t1, t2, t3);
        }
    }
}
