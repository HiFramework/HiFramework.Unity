//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using UnityEngine;

namespace HiFramework.Core.AsyncTask
{
    public class AsyncWwwTask : AsyncTask
    {
        private readonly WWW _www;

        public AsyncWwwTask(string url)
        {
            _www = new WWW(url);
        }

        protected override void Tick()
        {
            Debug.Log(_www.progress);
            if (_www.isDone)
                IsDone = true;
        }

        protected override void Complate()
        {
            Action(_www);
        }
    }
}


//public class TestAsyncWWWTask : MonoBehaviour
//{
//    void Start()
//    {
//        string url = "www.g.com";
//        new AsyncWwwTask(url).Start().OnFinish((p) =>
//        {
//            Debug.Log("download finish:" + ((WWW)p).bytes);
//        });
//    }
//}