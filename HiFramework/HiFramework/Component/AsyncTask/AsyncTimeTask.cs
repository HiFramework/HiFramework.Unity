using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncTimeTask : AsyncTask
    {
        private float _time;
        private float _waitTime;
        public AsyncTimeTask(Action<object> action, object obj, float waitTime) : base(action)
        {
            _time = Time.realtimeSinceStartup;
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
