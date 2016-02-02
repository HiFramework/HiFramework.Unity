using System;

namespace HiFramework
{
    public class Message
    {
        public object Data { get; private set; }
        public Action<Message> EventHandler { get; private set; }

        /// <summary>
        /// 构造消息,包含消息内容
        /// </summary>
        /// <param name="paramData"></param>
        public Message(object paramData)
            : this(paramData, null)
        {
        }

        /// <summary>
        /// 构造消息,包含消息内容和回调
        /// </summary>
        /// <param name="paramData"></param>
        /// <param name="paramHandler"></param>
        public Message(object paramData, Action<Message> paramHandler)
        {
            Data = paramData;
            EventHandler = paramHandler;
        }
    }
}
