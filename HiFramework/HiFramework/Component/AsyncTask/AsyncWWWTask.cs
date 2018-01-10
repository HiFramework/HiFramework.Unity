//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    class AsyncWWWTask : AsyncTaskWithParam<WWW>
    {
        private WWW _www;
        public AsyncWWWTask(Action<WWW> action, string url) : base(action)
        {
            _www = new WWW(url);
        }

        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (_www.isDone)
                IsDone = true;
        }

        protected override void Done()
        {
            Action(_www);
        }
    }
}
