//****************************************************************************
// Description:get ping time(repeating)
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using UnityEngine;
namespace HiFramework
{
    internal class AsyncRepeatingPingTask : AsyncTask
    {
        private readonly Action<int> _action;
        private readonly string _ip; //只包含ip,不包含接口
        private readonly float _timeOut;
        private float _timeStart;
        private Ping ping;

        public AsyncRepeatingPingTask(Action<int> action, string ip, float timeOut)
        {
            _timeStart = Time.realtimeSinceStartup;
            _action = action;
            _ip = ip;
            _timeOut = timeOut;
            Assert.IsFalse(ip.Contains(":"));
            ping = new Ping(_ip);
        }

        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup - _timeStart > _timeOut)
            {
                _timeStart = Time.realtimeSinceStartup;
                _action(ping.time);
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