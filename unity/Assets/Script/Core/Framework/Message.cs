//****************************************************************************
// Description:派发消息内容
// Author: hiramtan@live.com
//****************************************************************************

using System;
using System.Collections.Generic;
namespace HiFramework
{
    public class Message : ObjectBase, IMessage
    {
        public string Key { get; private set; }
        public List<object> Msg { get; private set; }

        //public Message(params object[] param) : this(null, param) { }
        public Message(string key, params object[] param)
        {
            Key = key;
            Msg = new List<object>(param);
        }

        protected override void OnDispose()
        {
            Msg.Clear();
            Msg = null;
        }

        #region Be very carefull when you use this method
        [Obsolete("You should use message dispather instead")]
        public Action<Message> CallBack { get; private set; }
        public Message(Action<Message> callback, string key, params object[] param)
        {
            Key = key;
            Msg = new List<object>(param);
            CallBack = callback;
        }
        #endregion
    }
}