using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncRepeatingTask : AsyncTask
    {
        private Action<object> _action;
        private object _obj;
        private readonly float _repeatingTime;
        private float _timeStart;

        public AsyncRepeatingTask(Action<object> action, object obj, float repeatingTime)
        {
            _action = action;
            _obj = obj;
            _timeStart = Time.realtimeSinceStartup;
            _repeatingTime = repeatingTime;
        }

        public void Stop()
        {
            IsDone = true;
        }

        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup >= _timeStart + _repeatingTime)
            {
                _timeStart = Time.realtimeSinceStartup;
                _action(_obj);
            }
        }

        protected override void Done()
        {
            //finish
        }
    }
}