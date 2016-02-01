using UnityEngine;
using System.Collections;
using System;

namespace HFramework
{
    public class Controller : IController
    {
        public Action<Message> viewEventHandler;

        public void DispatchMessage(Message paramMessage)
        {

        }

        public void OnMessage(Message paramMessage)
        {

        }

        public void Register()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
