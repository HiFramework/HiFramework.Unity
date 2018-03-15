//****************************************************************************
// Description: 异步www下载任务
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;

namespace HiFramework
{
    public class AsyncWWWTask : AsyncTaskWithParam<WWW>
    {
        private WWW _www;
        public AsyncWWWTask(Action<WWW> action, string url) : base(action)
        {
            _www = new WWW(url);
        }


        public override void Tick()
        {
            if (_www.isDone)
                Done();
        }

        protected override void Done()
        {
            base.Done();
            Action(_www);
        }

        void Test()
        {
            new AsyncWWWTask((x) =>
            {
                string log = x.bytes.ToString();
            }, "url");
        }
    }
}
