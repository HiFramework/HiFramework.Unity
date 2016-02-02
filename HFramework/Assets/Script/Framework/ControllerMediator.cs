using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class ControllerMediator : IController, IMessageDispatch
    {
        private IDictionary<string, Type> controllerMap;

        public ControllerMediator()
        {
            controllerMap = new Dictionary<string, Type>();
        }

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            string key = (string)Convert.ChangeType(paramKey, typeof(string));
            if (controllerMap.ContainsKey(key))
            {
                Type type = controllerMap[key];
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