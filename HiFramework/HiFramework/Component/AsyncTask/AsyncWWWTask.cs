using System;
using UnityEngine;

namespace HiFramework
{
    class AsyncWWWTask : AsyncTask
    {
        private WWW _www;
        public AsyncWWWTask(Action<object> action, string url) : base(action)
        {
            _www = new WWW(url);
        }

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
