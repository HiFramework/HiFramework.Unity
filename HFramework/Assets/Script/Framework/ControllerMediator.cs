using System;
using System.Collections.Generic;

namespace HFramework
{
    public class ControllerMediator
    {
        private IDictionary<string, Type> controllerMap;

        public ControllerMediator()
        {
            controllerMap = new Dictionary<string, Type>();
        }
        public void DispatchMessage(string paramKey, Message paramMessage)
        {
            if (controllerMap.ContainsKey(paramKey))
            {
                Type type = controllerMap[paramKey];
                object obj = Activator.CreateInstance(type);
                if (obj is Controller)
                    ((Controller)obj).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register key to controller first");
            }
        }
        public void Register<T>(string paramKey)
        {
            controllerMap[paramKey] = typeof(T);
        }

        public void Remove(string paramKey)
        {
            if (controllerMap.ContainsKey(paramKey))
                controllerMap.Remove(paramKey);
        }
    }
}