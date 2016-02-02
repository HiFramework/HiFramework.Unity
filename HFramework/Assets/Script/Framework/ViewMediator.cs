using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HiFramework
{
    public class ViewMediator : IView, IMessageDispatch
    {
        private IDictionary<IView, IController> controllerMap;
        public ViewMediator()
        {
            controllerMap = new Dictionary<IView, IController>();
        }

        public void Dispatch<T>(T paramKey, Message paramMessage)
        {
            IView key = (IView)Convert.ChangeType(paramKey, typeof(IView));
            if (controllerMap.ContainsKey(key))
            {
                IController controller = controllerMap[key];
                ((Controller)controller).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register view to controller first");
            }
        }

        public void Register(IView paramView, IController paramController)
        {
            controllerMap[paramView] = paramController;
        }
        public void Remove(IView paramView)
        {
            if (controllerMap.ContainsKey(paramView))
                controllerMap.Remove(paramView);
        }
    }
}
