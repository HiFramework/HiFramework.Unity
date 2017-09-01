//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncWwwTask : AsyncTask
    {
        private WWW _www;
        public AsyncWwwTask(string url, Action<object> action) : base(action)
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
//        new AsyncWWWTask(url).Start().Finish((p) =>
//        {
//            Debug.Log("download finish:" + ((WWW)p).bytes);
//        });
//    }
//}