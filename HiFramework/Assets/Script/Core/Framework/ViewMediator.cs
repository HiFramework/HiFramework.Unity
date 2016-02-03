using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HiFramework
{
    public class ViewMediator : IView, IMessageDispatch
    {
        private IDictionary<IView, object> controllerMap;
        public ViewMediator()
        {
            controllerMap = new Dictionary<IView, object>();
        }

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (controllerMap.ContainsKey(key))
            {
                object obj = controllerMap[key];
                if (obj is Controller)
                    ((Controller)obj).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register view to controller first");
            }
        }

        public void Register<T>(IView paramKey) where T : IController
        {
            if (!controllerMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                controllerMap[paramKey] = obj;
            }
        }

        public void Remove(IView paramView)
        {
            if (controllerMap.ContainsKey(paramView))
                controllerMap.Remove(paramView);
        }

        public void OnTick(float paramTime)
        {
            foreach (KeyValuePair<IView, object> param in controllerMap)
            {
                param.Key.OnTick(paramTime);
            }
        }
    }
}
