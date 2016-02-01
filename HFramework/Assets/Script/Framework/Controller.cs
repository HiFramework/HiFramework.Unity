using System;
using System.Collections.Generic;

namespace HFramework
{
    public class Controller : IController
    {
        private IDictionary<Message, Type> messageMap;

        public Controller()
        {
            messageMap = new Dictionary<Message, Type>();
        }

        public void Register(Message paramMessage, Type paramType)
        {
            messageMap[paramMessage] = paramType;
        }

        public void Execute(Message paramMessage)
        {
            if (messageMap.ContainsKey(paramMessage))
            {
                Type type = messageMap[paramMessage];
                object obj = Activator.CreateInstance(type);
                ((IController)obj).Execute(paramMessage);
            }
            else
            {
                UnityEngine.Debug.Log("You should register message first");
            }
        }
        public void Remove(Message paramMessage)
        {
            if (messageMap.ContainsKey(paramMessage))
                messageMap.Remove(paramMessage);
        }
    }
}