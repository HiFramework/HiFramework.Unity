//一定时间后执行某个逻辑
using System;
using HiFramework;
using UnityEngine;

namespace HiFramework
{
    public class AsyncWaitTask : AsyncTask
    {
        private object _obj;
        private float _waitTime;
        private float _startTime;
        public AsyncWaitTask(object obj, float waitTime, Action<object> action) : base(action)
        {
            this._obj = obj;
            this._waitTime = waitTime;
            _startTime = Time.realtimeSinceStartup;
        }
        protected override void Tick()
        {
            if (Time.realtimeSinceStartup > _startTime + _waitTime)
                IsDone = true;
        }

        protected override void Complate()
        {
            Action(_obj);
        }
    }
}

//public class Test
//{
//    void Start()
//    {
//        new AsyncWaitTask(null, Do1, 10f);//十秒钟后执行Do

//        new AsyncWaitTask(100, Do2, 10f);

//    }

//    void Do1(object obj)
//    {
//        Debug.Log("time pass");
//    }

//    void Do2(object obj)
//    {
//        Debug.Log((int)obj);
//    }
//}