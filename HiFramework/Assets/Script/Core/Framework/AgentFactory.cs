//****************************************************************************
// Description:命令/controller管理
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiFramework
{
    public class AgentFactory : IAgentFactory
    {
        public IDictionary<object, IAgent> agentMap { get; private set; }
        public AgentFactory()
        {
            agentMap = new Dictionary<object, IAgent>();
        }

        public void Dispatch(object paramKey, Message paramMessage)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (agentMap.ContainsKey(paramKey))
            {
                object obj = agentMap[paramKey];
                ((IAgent)obj).OnMessage(paramMessage);
            }
            else
                throw new Exception("You should register key to controller first");
        }

        public object Register<T>(object paramKey) where T : IAgent
        {
            if (!agentMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                agentMap[paramKey] = (IAgent)obj;
                return obj;
            }
            else
                throw new Exception("Dont need to regist this ilogic again");
        }
        public void Unregister(object paramKey)
        {
            if (agentMap.ContainsKey(paramKey))
                agentMap.Remove(paramKey);
            else
                throw new Exception("instantiation map dont contain this key");
        }

        public IAgent GetAgent(string paramName)
        {
            List<IAgent> objectList = new List<IAgent>(agentMap.Values);
            return objectList.Find(param => { return param.GetType().FullName == paramName; });
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~AgentFactory()
        {
            Dispose(false);
        }
        private bool disposed;
        void Dispose(bool paramDisposing)
        {
            if (disposed)
                return;
            if (paramDisposing)
            {
                for (int i = 0; i < agentMap.Count; i++)
                    agentMap.ElementAt(i).Value.Dispose();
                agentMap = null;
            }
            disposed = true;
        }
    }
}