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
        public IDictionary<object, object> LogicMap { get; set; }

        public Mediator()
        {
            LogicMap = new Dictionary<object, object>();
        }

        public void Dispatch(object paramKey, Message paramMessage)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (LogicMap.ContainsKey(paramKey))
            {
                object obj = LogicMap[paramKey];
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
            if (!LogicMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                LogicMap[paramKey] = obj;
            }
            else
            {
                throw new Exception("Dont need to regist this ilogic again");
            }
        }
        public void Unregister(object paramKey)
        {
            if (LogicMap.ContainsKey(paramKey))
                LogicMap.Remove(paramKey);
            else
            {
                throw new Exception("logic map dont contain this key");
            }
        }
    }
}