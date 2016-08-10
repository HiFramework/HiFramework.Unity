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
        public IDictionary<object, object> InstantiationMap { get; private set; }

        public Mediator()
        {
            InstantiationMap = new Dictionary<object, object>();
        }

        public void Dispatch(object paramKey, Message paramMessage)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (InstantiationMap.ContainsKey(paramKey))
            {
                object obj = InstantiationMap[paramKey];
                if (obj is ILogic)
                    ((ILogic)obj).OnMessage(paramMessage);
            }
            else
            {
                throw new Exception("You should register key to controller first");
            }
        }

        public void Register<T>(object paramKey) where T : ILogic
        {
            if (!InstantiationMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                InstantiationMap[paramKey] = obj;
            }
            else
            {
                throw new Exception("Dont need to regist this ilogic again");
            }
        }
        public void Unregister(object paramKey)
        {
            if (InstantiationMap.ContainsKey(paramKey))
                InstantiationMap.Remove(paramKey);
            else
            {
                throw new Exception("instantiation map dont contain this key");
            }
        }
    }
}