using UnityEngine;
using System.Collections;
using System;

namespace HFramework
{
    public class Controller : IMessage
    {
        public Action<Message> viewEventHandler;

        public void DispatchMessage(Message paramMessage)
        {

        }

        public void OnMessage(Message paramMessage)
        {

        }
    }
}
