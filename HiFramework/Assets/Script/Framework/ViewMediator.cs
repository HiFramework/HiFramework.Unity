using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HiFramework
{
    public class ViewMediator : IView, IMessageDispatch
    {
        private IDictionary<IView, Type> controllerMap;
        public ViewMediator()
        {
            controllerMap = new Dictionary<IView, Type>();
        }

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (controllerMap.ContainsKey(key))
            {
                Type type = controllerMap[key];
                object obj = Activator.CreateInstance(type);
                if (obj is Controller)
                    ((Controller)obj).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register view to controller first");
            }
        }
        public void Register<T>(IView paramKey)
        {
            controllerMap[paramKey] = typeof(T);
        }

        public void Remove(IView paramView)
        {
            if (controllerMap.ContainsKey(paramView))
                controllerMap.Remove(paramView);
        }
    }
}
