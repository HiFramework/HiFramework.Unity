using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HiFramework
{
    class AsyncTaskWaitTime : TaskBase
    {
        float _startTime;
        float _waitTime;

        public AsyncTaskWaitTime(Action action, float waitTime) : base(action)
        {
            _startTime = Time.realtimeSinceStartup;
            _waitTime = waitTime;
        }

        public override void Tick(float time)
        {
            if (Time.realtimeSinceStartup - _startTime > _waitTime)
            {
                Finish();
                Action();
            }
        }
    }
}