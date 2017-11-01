using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncTimeTask : AsyncTask
    {
        private Action<object> _action;
        private object _obj;
        private float _time;
        private float _waitTime;
        public AsyncTimeTask(Action<object> action, object obj, float waitTime)
        {
            _action = action;
            _obj = obj;
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
            _action(_obj);
        }
    }
}
