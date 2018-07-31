//****************************************************************************
// Description: 异步任务:一段时间后执行
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncTimeTask : AsyncTaskNoParam
    {
        private float _time;
        private float _waitTime;
        public AsyncTimeTask(Action action, float waitTime) : base(action)
        {
            _time = Time.realtimeSinceStartup;
            _waitTime = waitTime;
        }


        public override void Tick(float deltaTime)
        {
            if (Time.realtimeSinceStartup - _time >= _waitTime)
                Done();
        }
    }
}
//void Test()
//{
//new AsyncTimeTask(() =>
//{
//    string log = "execute";
//}, 1);
//}
