//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;
using HiFramework.Core;

namespace HiFramework.Unity
{
    internal class MainThreadComponent : ComponentBase, ITick, IMainThread
    {
        private ITickComponent _tickComponent;
        /// <summary>
        /// 待执行列表
        /// </summary>
        private readonly Queue<ToExecute> toWaitRunOnMainThread = new Queue<ToExecute>();

        private readonly object locker = new object();

        /// <summary>
        /// obj不能可选为空,数据会被线程冲刷,需要传递原有数据
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        public void RunOnMainThread(Action<object> action, object obj)
        {
            lock (locker)
            {
                toWaitRunOnMainThread.Enqueue(new ToExecute(action, obj));
            }
        }

        public void Tick(float deltaTime)
        {
            lock (locker)
            {
                while (toWaitRunOnMainThread.Count > 0)
                {
                    var per = toWaitRunOnMainThread.Dequeue();
                    per.Action(per.Args);
                    per.Dispose();
                }
            }
        }
        /// <summary>
        /// 待执逻辑
        /// </summary>
        private class ToExecute : IDisposable
        {
            public Action<object> Action { get; private set; }
            public object Args { get; private set; }

            public ToExecute(Action<object> action, object args)
            {
                Action = action;
                Args = args;
            }
            /// <summary>执行与释放或重置非托管资源关联的应用程序定义的任务。</summary>
            public void Dispose()
            {
                Action = null;
                Args = null;
            }
        }

        public override void OnCreated()
        {
            _tickComponent = Center.Get<ITickComponent>();
            _tickComponent.Regist(this);
        }

        public override void Dispose()
        {
            _tickComponent.Unregist(this);
        }
    }
}
