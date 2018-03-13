//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncRepeatingTask : AsyncTask
    {
        private Action _action;
        private readonly float _repeatingTime;
        private float _timeStart;

        public AsyncRepeatingTask(float repeatingTime)
        {
            _timeStart = Time.realtimeSinceStartup;
            _repeatingTime = repeatingTime;
        }
        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup >= _timeStart + _repeatingTime)
            {
                _timeStart = Time.realtimeSinceStartup;
                _action();
            }
        }

        protected override void Done()
        {
            //finish
        }
    }
}