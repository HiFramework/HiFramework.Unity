//****************************************************************************
// Description:注册与派发
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiFramework
{
    public class AgentMap : ObjectBase, IRegistAndDispatch
    {
        private IDictionary<object, Agent> _agentMap = new Dictionary<object, Agent>();

        public void Dispatch(object paramKey, IMessage paramMessage = null)
        {
            //IView key = (IView)Convert.ChangeType(paramKey, paramKey.GetType());
            if (_agentMap.ContainsKey(paramKey))
            {
                Agent obj = _agentMap[paramKey];
                obj.OnMessage(paramMessage);
            }
            else
                throw new Exception("You should _map key to controller first");
        }

        public object Regist<T>(object paramKey) where T : Agent
        {
            if (!_agentMap.ContainsKey(paramKey))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                _agentMap[paramKey] = (Agent)obj;
                return obj;
            }
            else
                throw new Exception("Dont need to regist this ilogic again");
        }
        public void Unregist(object paramKey)
        {
            if (_agentMap.ContainsKey(paramKey))
                _agentMap.Remove(paramKey);
            else
                throw new Exception("instantiation map dont contain this key");
        }
        public T GetAgent<T>() where T : Agent
        {
            List<Agent> objectList = new List<Agent>(_agentMap.Values);
            var agent = objectList.Find(param => { return param.GetType() == typeof(T); });
            if (agent == null)
                return null;
            return (T)agent;
        }

        protected override void OnDispose()
        {
            for (int i = 0; i < _agentMap.Count; i++)
                _agentMap.ElementAt(i).Value.Dispose();
            _agentMap.Clear();
            _agentMap = null;
        }
    }
}