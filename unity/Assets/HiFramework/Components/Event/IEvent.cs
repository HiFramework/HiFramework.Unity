//****************************************************************************
// Description:
// of cource you can use event, but the recommend is use signal.
// Author: hiramtan@live.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface IEvent
    {
        /// <summary>
        /// 可以多次注册,信号量同时多次触发
        /// 即便是无参数的回调，也强制采用这种方式
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        void Regist(string key, Action<object[]> action);

        /// <summary>
        /// 取消注册事件
        /// </summary>
        /// <param name="key"></param>
        void Unregist(string key);

        /// <summary>
        /// 派发事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        void Dispatch(string key, params object[] obj);
    }
}
