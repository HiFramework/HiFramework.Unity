//****************************************************************************
// Description: 异步任务:一段时间后执行
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncTimeTask : AsyncTask
    {
        private Action _action;
        private float _time;
        private float _waitTime;
        public AsyncTimeTask(Action action, float waitTime)
        {
            _action = action;
            _time = Time.realtimeSinceStartup;
            _waitTime = waitTime;
        }

        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup - _time >= _waitTime)
                IsDone = true;
        }

        protected override void Done()
        {
            _action();
        }
    }
}
