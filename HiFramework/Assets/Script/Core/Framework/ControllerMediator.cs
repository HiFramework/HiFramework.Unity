using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class ControllerMediator : IController, IMessageDispatch
    {
        private IDictionary<string, object> controllerMap;

        public ControllerMediator()
        {
            controllerMap = new Dictionary<string, object>();
        }

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            string key = (string)Convert.ChangeType(paramKey, typeof(string));
            if (controllerMap.ContainsKey(key))
            {
                object obj = controllerMap[key];
                if (obj is Controller)
                    ((Controller)obj).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register key to controller first");
            }
        }
        public void Register<T>(string paramKey) where T : IController
        {
            if (!controllerMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                controllerMap[paramKey] = obj;
            }
        }

        public void Remove(string paramKey)
        {
            if (controllerMap.ContainsKey(paramKey))
                controllerMap.Remove(paramKey);
        }
    }
}