//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class MainThreadComponent : Component, ITick, IMainThread
    {
        private readonly Queue<ToExecute> toExecuteQueue = new Queue<ToExecute>();
        private readonly List<Action> applicationQuitActionList = new List<Action>();
        private static readonly object Locker = new object();

        /// <summary>
        /// obj不能可选为空,数据会被线程冲刷,需要传递原有数据
        /// </summary>
        /// <param name="action"></param>
        /// <param name="obj"></param>
        public void RunOnMainThread(Action<object> action, object obj)
        {
            lock (Locker)
            {
                toExecuteQueue.Enqueue(new ToExecute(action, obj));
            }
        }

        public void RunOnApplicationQuit(Action action)
        {
            AssertThat.IsFalse(applicationQuitActionList.Contains(action));
            applicationQuitActionList.Add(action);
        }

        public void Quit()
        {
            foreach (var variable in applicationQuitActionList)
            {
                variable();
            }
        }

        public void Tick()
        {
            lock (Locker)
            {
                if (toExecuteQueue.Count > 0)
                {
                    while (toExecuteQueue.Count > 0)
                    {
                        var per = toExecuteQueue.Dequeue();
                        per.Action(per.Obj);
                    }
                }
            }
        }
        private class ToExecute
        {
            public ToExecute(Action<object> action, object obj)
            {
                Action = action;
                Obj = obj;
            }

            public Action<object> Action { get; private set; }
            public object Obj { get; private set; }
        }
    }
}
