/****************************************************************************
 * Description:每隔一段时间获取当前网络ping值
 *
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using UnityEngine;
namespace HiFramework
{
    public class AsyncRepeatingPingTask : AsyncTaskWithParam<int>
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
            AssertThat.IsFalse(ip.Contains(":"));
            ping = new Ping(_ip);
        }

        public override void Tick(float deltaTime)
        {
            if (Time.realtimeSinceStartup - _timeStart > _rate)
            {
                _timeStart = Time.realtimeSinceStartup;
                Action(ping.time);
                ping.DestroyPing();
                ping = new Ping(_ip);
            }
        }
    }
}

//public void TestMethod()
//{
//new AsyncRepeatingPingTask(x =>
//{
//    string log = "current ping is: " + x;
//}, "ip", 1);
//}