using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace HFramework
{
    public class ViewMediator
    {
        private Dictionary<IView, Controller> viewMap;
        public ViewMediator()
        {
            viewMap = new Dictionary<IView, Controller>();
        }

        public void DispatchMessage(IView paramView, Message paramMessage)
        {
            if (viewMap.ContainsKey(paramView))
            {
                Controller controller = viewMap[paramView];
                controller.OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register view to controller first");
            }
        }
        public void Register(IView paramView, Controller paramController)
        {
            viewMap[paramView] = paramController;
        }
        public void Remove(IView paramView)
        {
            if (viewMap.ContainsKey(paramView))
                viewMap.Remove(paramView);
        }
    }
}
