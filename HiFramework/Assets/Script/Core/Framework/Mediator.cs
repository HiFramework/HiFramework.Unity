//****************************************************************************
// Description:命令/controller管理
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class Mediator : IMediator
    {
        public IDictionary<object, object> controllerMap { get;  set; }

        public Mediator()
        {
            controllerMap = new Dictionary<object, object>();
        }

        public void Dispatch(object paramKey, Message paramMessage)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (controllerMap.ContainsKey(paramKey))
            {
                object obj = controllerMap[paramKey];
                if (obj is Logic)
                    ((Logic)obj).OnMessage(paramMessage);
            }
            else
            {
                UnityEngine.Debug.LogError("You should register key to controller first");
            }
        }

        public void Register<T>(object paramKey) where T : ILogic
        {
            if (!controllerMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                controllerMap[paramKey] = obj;
            }
        }
        public void Unregister(object paramKey)
        {
            if (controllerMap.ContainsKey(paramKey))
                controllerMap.Remove(paramKey);
        }
    }
}