/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{

    public class Signal<T> : SignalBase, ISignal<T>
    {
        private event Action<T> OnEvent;
        /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
        public override void Dispose()
        {
            OnEvent = null;
        }

        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action<T> action)
        {
            OnEvent += action;
        }

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        public void RemoveListener(Action<T> action)
        {
            OnEvent -= action;
        }

        /// <summary>
        /// Fire the signal
        /// </summary>
        /// <param name="args"></param>
        public void Fire(T args)
        {
            OnEvent(args);
        }
    }

}
