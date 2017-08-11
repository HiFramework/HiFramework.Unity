//一定时间后执行某个逻辑
using System;
using HiFramework;
using UnityEngine;

namespace HiFramework
{
    public class AsyncWaitTask : AsyncTask
    {
        private object obj;
        private Action<object> finishAction;
        private float waitTime;
        private float startTime;
        public AsyncWaitTask(object obj, Action<object> finishAction, float waitTime)
        {
            this.obj = obj;
            this.waitTime = waitTime;
            this.finishAction = finishAction;
            startTime = Time.realtimeSinceStartup;
        }
        protected override void Update()
        {
            if (Time.realtimeSinceStartup > startTime + waitTime)
                isDone = true;
        }

        protected override void Complate()
        {
            finishAction(obj);
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