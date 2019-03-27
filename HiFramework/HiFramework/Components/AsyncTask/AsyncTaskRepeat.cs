/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HiFramework
{
    public class AsyncTaskRepeat : TaskBase
    {
        float _startTime;
        private float _repeatTime;

        public AsyncTaskRepeat(Action action, float repeatTime) : base(action)
        {
            _repeatTime = repeatTime;
        }

        public override void Tick(float time)
        {
            if (Time.realtimeSinceStartup - _startTime > _repeatTime)
            {
                _startTime += _repeatTime;
                Action();
            }
        }

        public void Stop()
        {
            Finish();
        }
    }
}