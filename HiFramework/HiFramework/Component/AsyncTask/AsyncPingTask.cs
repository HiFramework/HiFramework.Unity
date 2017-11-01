//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using UnityEngine;

namespace HiFramework
{
    class AsyncPingTask : AsyncTask
    {
        private float _timeStart;
        private string _ip;
        private float _timeOut;
        private Ping ping;
        public AsyncPingTask(Action<object> action, string ip, float timeOut) : base(action)
        {
            _timeStart = Time.realtimeSinceStartup;
            Action = action;
            _ip = ip;
            _timeOut = timeOut;
            Assert.IsFalse(ip.Contains(":"));
            ping = new Ping(_ip);
        }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup - _timeStart > _timeOut)
            {
                _timeStart = Time.realtimeSinceStartup;
                Action(ping.time);
                ping.DestroyPing();
                ping = new Ping(_ip);
            }
        }

        protected override void Done()
        {
            //will not run, because this is instance should always tick run
        }
    }
}
