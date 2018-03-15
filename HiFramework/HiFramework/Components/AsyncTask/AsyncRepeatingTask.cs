//****************************************************************************
// Description: 定时重复执行异步任务
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncRepeatingTask : AsyncTaskNoParam
    {
        private readonly float _repeatingTime;
        private float _timeStart;

        public AsyncRepeatingTask(Action action, float repeatingTime) : base(action)
        {
            _timeStart = Time.realtimeSinceStartup;
            _repeatingTime = repeatingTime;
        }

        public override void Tick()
        {
            if (Time.realtimeSinceStartup >= _timeStart + _repeatingTime)
            {
                _timeStart = Time.realtimeSinceStartup;
                Action();
            }
        }
    }
}
//void Test()
//{
//new AsyncRepeatingTask(() =>
//{
//    string log = "execute";
//}, 1);
//}