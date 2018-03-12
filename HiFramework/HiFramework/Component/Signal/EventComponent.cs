//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class EventComponent : Component, IEvent
    {
        private class HandlerInfo
        {
            public object Obj { get; }

            public Action<object> Action { get; }

            public HandlerInfo(Action<object> action, object obj)
            {
                Obj = obj;
                Action = action;
            }
        }
        private readonly Dictionary<string, List<HandlerInfo>> _handlers = new Dictionary<string, List<HandlerInfo>>();

        public void Regist(string key, Action<object> action, object obj = null)
        {
            if (_handlers.ContainsKey(key))
            {
                var infos = _handlers[key];
                infos.Add(new HandlerInfo(action, obj));
            }
            else
            {
                var list = new List<HandlerInfo>();
                list.Add(new HandlerInfo(action, obj));
                _handlers.Add(key, list);
            }
        }

        public void Unregist(string key)
        {
            Assert.IsTrue(_handlers.ContainsKey(key));
            _handlers[key].Clear();
            _handlers.Remove(key);
        }

        public void Unregist(string key, Action<object> action)
        {
            Assert.IsTrue(_handlers.ContainsKey(key));
            var info = _handlers[key].Find((x) => { return x.Action == action; });
            Assert.IsNotNull(info);
            _handlers[key].Remove(info);
        }

        public void Dispatch(string key)
        {
            Assert.IsNotNull(_handlers.ContainsKey(key));
            var infos = _handlers[key];
            foreach (var variable in infos)
            {
                variable.Action(variable.Obj);
            }
        }

        public EventComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void UnRegistComponent()
        {
            foreach (var variable in _handlers)
            {
                variable.Value.Clear();
            }
            _handlers.Clear();
        }
    }
}
