//****************************************************************************
// Description:派发消息内容
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public class Message : IDisposable
    {
        public object key { get; private set; }
        public List<object> message { get; private set; }
        private bool disposed;
        public Message(object paramKey = null, params object[] param)
        {
            key = paramKey;
            message = new List<object>();
            for (int i = 0, length = param.Length; i < length; i++)
                message.Add(param[i]);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Message()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                message = null;
            }
            disposed = true;
        }

        #region Be very carefull when you use this method
        [Obsolete("You should use message dispather instead")]
        public Action<Message> callBack { get; private set; }
        public Message(Action<Message> callback, params object[] param)
        {
            message = new List<object>();
            for (int i = 0, length = param.Length; i < length; i++)
                message.Add(param[i]);
        }
        #endregion
    }
}