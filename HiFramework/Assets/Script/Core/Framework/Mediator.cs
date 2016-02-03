using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class Mediator : ICommand, IMessageDispatch
    {
        private IDictionary<object, object> controllerMap;

        public Mediator()
        {
            controllerMap = new Dictionary<object, object>();
        }

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            object key = paramKey;
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

        public void Register<T>(object paramKey) where T : IController
        {
            if (!controllerMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                controllerMap[paramKey] = obj;
            }
        }
        public void Remove(object paramKey)
        {
            if (controllerMap.ContainsKey(paramKey))
                controllerMap.Remove(paramKey);
        }
    }
}