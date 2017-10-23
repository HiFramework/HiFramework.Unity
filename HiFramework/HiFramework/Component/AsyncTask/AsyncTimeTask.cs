using System;
using UnityEngine;

namespace HiFramework
{
    class AsyncTimeTask : AsyncTask
    {
        private float _time;
        private float _waitTime;
        public AsyncTimeTask(Action<object> action, object obj, float waitTime)
        {
            _time = Time.realtimeSinceStartup;
            Action = action;
            Obj = obj;
            _waitTime = waitTime;
        }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup - _time >= _waitTime)
                IsDone = true;
        }

        protected override void Done()
        {
            Action(Obj);
        }
    }
}
