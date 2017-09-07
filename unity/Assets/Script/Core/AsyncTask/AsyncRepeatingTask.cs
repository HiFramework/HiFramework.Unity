//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************

using System;
using UnityEngine;

namespace Assets.Script.Core.AsyncTask
{
    internal class AsyncRepeatingTask : HiFramework.Core.AsyncTask.AsyncTask
    {
        private readonly Action<object> _action;
        private readonly object _obj;
        private readonly float _repeatingTime;
        private bool _isStop;
        private float _timeStart;

        public AsyncRepeatingTask(Action<object> action, float repeatingTime, object obj = null)
        {
            _timeStart = Time.realtimeSinceStartup;
            _action = action;
            _repeatingTime = repeatingTime;
            _obj = obj;
        }

        public void Stop()
        {
            _isStop = true;
        }

        protected override void Tick()
        {
            if (Time.realtimeSinceStartup >= _timeStart + _repeatingTime)
            {
                _timeStart = Time.realtimeSinceStartup;
                _action(_obj);
            }
            IsDone = _isStop;
        }

        protected override void Complate()
        {
            throw new NotImplementedException();
        }
    }
}