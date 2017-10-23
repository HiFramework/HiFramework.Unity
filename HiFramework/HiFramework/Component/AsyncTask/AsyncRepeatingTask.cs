using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncRepeatingTask : AsyncTask
    {
        private readonly float _repeatingTime;
        private float _timeStart;

        public AsyncRepeatingTask(Action<object> action, object obj, float repeatingTime) : base(action)
        {
            _timeStart = Time.realtimeSinceStartup;
            _repeatingTime = repeatingTime;
            Obj = obj;
        }

        public void Stop()
        {
            IsDone = true;
        }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup >= _timeStart + _repeatingTime)
            {
                _timeStart = Time.realtimeSinceStartup;
                Action(Obj);
            }
        }

        protected override void Done()
        {
            //finish
        }
    }
}