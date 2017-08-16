//****************************************************************************
// Description:注册与派发
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiFramework
{
    public class AgentRegister : ObjectBase, IRegist, IDispatch
    {
        public IDictionary<object, Agent> agentMap;
        public AgentRegister()
        {
            agentMap = new Dictionary<object, Agent>();
        }

        public void Dispatch(object paramKey, Message paramMessage = null)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (agentMap.ContainsKey(paramKey))
            {
                Agent obj = agentMap[paramKey];
                obj.OnMessage(paramMessage);
            }
            else
                throw new Exception("You should register key to controller first");
        }

        public object Regist<T>(object paramKey) where T : Agent
        {
            if (!agentMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                agentMap[paramKey] = (Agent)obj;
                return obj;
            }
            else
                throw new Exception("Dont need to regist this ilogic again");
        }
        public void Unregist(object paramKey)
        {
            if (agentMap.ContainsKey(paramKey))
                agentMap.Remove(paramKey);
            else
                throw new Exception("instantiation map dont contain this key");
        }

        public Agent GetAgentByKey(object key)
        {
            if (!agentMap.ContainsKey(key))
                return null;
            return agentMap[key];
        }

        public Agent GetAgentByType(Type type)
        {
            List<Agent> objectList = new List<Agent>(agentMap.Values);
            return objectList.Find(param => { return param.GetType() == type; });
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < agentMap.Count; i++)
                agentMap.ElementAt(i).Value.Dispose();
            agentMap = null;
        }
    }
}