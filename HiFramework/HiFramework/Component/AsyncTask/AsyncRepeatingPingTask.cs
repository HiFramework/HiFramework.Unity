//****************************************************************************
// Description:get ping time(repeating)
// Author: hiramtan@live.com
//****************************************************************************
using System;
using UnityEngine;
namespace HiFramework
{
    internal class AsyncRepeatingPingTask : AsyncTaskWithParam<int>
    {
        private readonly string _ip; //只包含ip,不包含接口
        private readonly float _rate;//更新频率
        private float _timeStart;
        private Ping ping;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="ip">ip地址</param>
        /// <param name="rate">多久ping一次</param>
        public AsyncRepeatingPingTask(Action<int> action, string ip, float rate) : base(action)
        {
            _timeStart = Time.realtimeSinceStartup;
            Action = action;
            _ip = ip;
            _rate = rate;
            Assert.IsFalse(ip.Contains(":"));
            ping = new Ping(_ip);
        }
        protected override bool IsDone { get; set; }

        protected override void OnTick()
        {
            if (Time.realtimeSinceStartup - _timeStart > _rate)
            {
                _timeStart = Time.realtimeSinceStartup;
                Action(ping.time);
                ping.DestroyPing();
                ping = new Ping(_ip);
            }
        }

        protected override void Done()
        {
            //will not run, because this is repeating
        }
    }
}