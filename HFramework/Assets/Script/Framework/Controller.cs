using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    public class Controller : IController, IMessage
    {
        public Action<Message> viewEventHandler;

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {

        }

        public virtual void OnMessage(Message paramMessage)
        {

        }

        public void Register<T>(string paramKey)
        {
            Facade.Controller.Register<T>(paramKey);
        }

        public void Remove(string paramKey)
        {
            Facade.Controller.Remove(paramKey);
        }
    }
}
