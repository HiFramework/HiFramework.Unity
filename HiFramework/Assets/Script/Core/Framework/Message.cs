using System;

namespace HiFramework
{
    public class Message
    {
        public string ID { get; private set; }//消息号
        public object Body { get; private set; }//消息内容
        [Obsolete("Be carefull when you use message's callback")]
        public Action<Message> EventHandler { get; private set; }//慎用回调

        /// <summary>
        /// 构造消息id
        /// </summary>
        /// <param name="paramID"></param>
        public Message(string paramID) :
            this(paramID, null)
        {

        }
        /// <summary>
        /// 构造消息,包含消息内容
        /// </summary>
        /// <param name="paramData"></param>
        public Message(string paramID, object paramBody)
            : this(paramID, paramBody, null)
        {
        }

        /// <summary>
        /// 构造消息,包含消息内容和回调
        /// </summary>
        /// <param name="paramData"></param>
        /// <param name="paramHandler"></param>
        public Message(string paramID, object paramBody, Action<Message> paramHandler)
        {
            ID = paramID;
            Body = paramBody;
            EventHandler = paramHandler;
        }
    }
}
