using System;
using System.Collections.Generic;

namespace HFramework
{
    public class ControllerMediator
    {
        private IDictionary<Message, Type> messageMap;

        public ControllerMediator()
        {
            messageMap = new Dictionary<Message, Type>();
        }
        public void DispatchMessage(Message paramMessage)
        {
            if (messageMap.ContainsKey(paramMessage))
            {
                Type type = messageMap[paramMessage];
                object obj = Activator.CreateInstance(type);
                if (obj is Controller)
                    ((Controller)obj).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register message to controller first");
            }
        }
        public void Register(Message paramMessage, Type paramType)
        {
            messageMap[paramMessage] = paramType;
        }

        public void Remove(Message paramMessage)
        {
            if (messageMap.ContainsKey(paramMessage))
                messageMap.Remove(paramMessage);
        }
    }
}