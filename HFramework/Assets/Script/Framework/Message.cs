using System;

namespace HiFramework
{
    public class Message
    {
        public string name { get; private set; }
        public object body { get; private set; }
        public Action eventHandler { get; private set; }

        /// <summary>
        /// 消息名(或ID)
        /// </summary>
        /// <param name="paramName"></param>
        public Message(string paramName)
            : this(paramName, null)
        {
        }
        /// <summary>
        /// 构造消息(包含内容)
        /// </summary>
        /// <param name="paramMessage"></param>
        public Message(string paramName, object paramBody)
            : this(paramName, paramBody, null)
        {
        }
        /// <summary>
        /// 构造消息(包含内容和回调)
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramMessage"></param>
        /// <param name="paramHandler"></param>
        public Message(string paramName, object paramBody, Action paramHandler)
        {
            name = paramName;
            body = paramBody;
            eventHandler = paramHandler;
        }
    }
}
