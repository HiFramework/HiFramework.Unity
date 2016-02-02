using System;

namespace HiFramework
{
    public class Message
    {
        public string ID { get; private set; }
        public object Body { get; private set; }
        public Action<Message> EventHandler { get; private set; }

        /// <summary>
        /// 消息名(或ID)
        /// </summary>
        /// <param name="paramName"></param>
        public Message(string paramID)
            : this(paramID, null)
        {
        }
        /// <summary>
        /// 构造消息(包含内容)
        /// </summary>
        /// <param name="paramMessage"></param>
        public Message(string paramID, object paramBody)
            : this(paramID, paramBody, null)
        {
        }
        /// <summary>
        /// 构造消息(包含内容和回调)
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramMessage"></param>
        /// <param name="paramHandler"></param>
        public Message(string paramID, object paramBody, Action<Message> paramHandler)
        {
            ID = paramID;
            Body = paramBody;
            EventHandler = paramHandler;
        }
    }
}
