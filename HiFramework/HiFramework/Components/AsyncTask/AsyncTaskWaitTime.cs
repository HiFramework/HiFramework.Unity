/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncTaskWaitTime : TaskBase
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