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
            public Action<object[]> Action { get; }

            public HandlerInfo(Action<object[]> action)
            {
                Action = action;
            }
        }
        private readonly Dictionary<string, List<HandlerInfo>> _maps = new Dictionary<string, List<HandlerInfo>>();

        public void Regist(string key, Action<object[]> action)
        {
            if (_maps.ContainsKey(key))
            {
                var infos = _maps[key];
                infos.Add(new HandlerInfo(action));
            }
            else
            {
                var list = new List<HandlerInfo>();
                list.Add(new HandlerInfo(action));
                _maps.Add(key, list);
            }
        }

        public void Unregist(string key)
        {
            Assert.IsTrue(_maps.ContainsKey(key));
            _maps[key].Clear();
            _maps.Remove(key);
        }

        public void Unregist(string key, Action<object[]> action)
        {
            Assert.IsTrue(_maps.ContainsKey(key));
            var info = _maps[key].Find((x) => { return x.Action == action; });
            Assert.IsNotNull(info);
            _maps[key].Remove(info);
        }

        public void Dispatch(string key, params object[] obj)
        {
            Assert.IsNotNull(_maps.ContainsKey(key));
            var infos = _maps[key];
            foreach (var variable in infos)
            {
                variable.Action(obj);
            }
        }

        public EventComponent(IContainer iContainer) : base(iContainer)
        {
        }
        public override void OnInit()
        {
        }

        public override void OnClose()
        {
            foreach (var variable in _maps)
            {
                variable.Value.Clear();
            }
            _maps.Clear();
        }
    }
}
