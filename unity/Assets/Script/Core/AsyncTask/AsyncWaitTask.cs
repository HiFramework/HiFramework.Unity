//一定时间后执行某个逻辑

using UnityEngine;

namespace HiFramework.Core.AsyncTask
{
    public class AsyncWaitTask : AsyncTask
    {
        private readonly object _obj;
        private readonly float _startTime;
        private readonly float _waitTime;

        public AsyncWaitTask(object obj, float waitTime)
        {
            _obj = obj;
            _waitTime = waitTime;
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
//        new AsyncWaitTask(null, 10f).OnFinish(Do1);//十秒钟后执行Do1
//        new AsyncWaitTask(new GameObject(), 10f).OnFinish(Do2);
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