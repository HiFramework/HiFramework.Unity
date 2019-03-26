/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{

    public class Signal : SignalBase, ISignal
    {
        /// <summary>
        /// Event
        /// </summary>
        private event Action OnEvent;


        public Signal(string name) : base(name)
        {
        }

        /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
        public override void Dispose()
        {
            OnEvent = null;
        }

        /// <summary>
        /// Add listener to monitor event
        /// </summary>
        /// <param name="action"></param>
        public void AddListener(Action action)
        {
            OnEvent += action;
        }

        /// <summary>
        /// Remove listener
        /// </summary>
        /// <param name="action"></param>
        public void RemoveListener(Action action)
        {
            OnEvent -= action;
        }

        /// <summary>
        /// Fire the signal
        /// </summary>
        public void Fire()
        {
            if (OnEvent != null)
            {
                OnEvent();
            }
            else
            {
                Console.WriteLine("Event's action is null");
            }
        }
    }
}
