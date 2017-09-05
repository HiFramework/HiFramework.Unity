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

        public void Dispatch(object key, IMessage message = null)
        {
            //IView key = (IView)Convert.ChangeType(key, key.GetType());
            if (_agentMap.ContainsKey(key))
            {
                Agent obj = _agentMap[key];
                obj.OnMessage(message);
            }
            else
                throw new Exception("You should _map key to controller first");
        }

        public object Regist<T>(object key) where T : Agent
        {
            if (!_agentMap.ContainsKey(key))
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                _agentMap[key] = (Agent)obj;
                return obj;
            }
            else
                throw new Exception("Dont need to regist this ilogic again");
        }
        public void Unregist(object key)
        {
            if (_agentMap.ContainsKey(key))
                _agentMap.Remove(key);
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