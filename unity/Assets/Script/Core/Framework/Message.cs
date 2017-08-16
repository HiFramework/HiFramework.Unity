//****************************************************************************
// Description:派发消息内容
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public class Message : ObjectBase
    {
        public object Key { get; private set; }
        public List<object> Msg { get; private set; }

        public Message(params object[] param) : this(null, param) { }
        public Message(object paramKey, params object[] param)
        {
            Key = paramKey;
            Msg = new List<object>(param);
        }

        protected override void OnDispose()
        {
            Msg.Clear();
            Msg = null;
        }

        //#region Be very carefull when you use this method
        //[Obsolete("You should use message dispather instead")]
        //public Action<Message> callBack { get; private set; }
        //public Message(Action<Message> callback, params object[] param)
        //{
        //    Msg = new List<object>();
        //    for (int i = 0, length = param.Length; i < length; i++)
        //        Msg.Add(param[i]);
        //}
        //#endregion
    }
}