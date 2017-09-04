//一定时间后执行某个逻辑
using UnityEngine;

namespace HiFramework
{
    public class AsyncWaitTask : AsyncTask
    {
        private object _obj;
        private float _waitTime;
        private float _startTime;
        public AsyncWaitTask(object obj, float waitTime)
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