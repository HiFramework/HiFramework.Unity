//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class SignalComponent : Component, ISignal
    {
        private class SignalInfo
        {
            public object Obj { get; }

            public Action<object> Action { get; }

            public SignalInfo(Action<object> action, object obj)
            {
                Obj = obj;
                Action = action;
            }
        }
        private Dictionary<string, List<SignalInfo>> _signals = new Dictionary<string, List<SignalInfo>>();

        public void Regist(string key, Action<object> action, object obj = null)
        {
            if (_signals.ContainsKey(key))
            {
                var infos = _signals[key];
                infos.Add(new SignalInfo(action, obj));
            }
            else
            {
                var list = new List<SignalInfo>();
                list.Add(new SignalInfo(action, obj));
                _signals.Add(key, list);
            }
        }

        public void Unregist(string key)
        {
            Assert.IsTrue(_signals.ContainsKey(key));
            _signals[key].Clear();
            _signals.Remove(key);
        }

        public void Unregist(string key, Action<object> action)
        {
            Assert.IsTrue(_signals.ContainsKey(key));
            var info = _signals[key].Find((x) => { return x.Action == action; });
            Assert.IsNotNull(info);
            _signals[key].Remove(info);
        }

        public void Dispatch(string key)
        {
            Assert.IsNotNull(_signals.ContainsKey(key));
            var infos = _signals[key];
            foreach (var variable in infos)
            {
                variable.Action(variable.Obj);
            }
        }
        
        public SignalComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void UnRegistComponent()
        {
            foreach (var variable in _signals)
            {
                variable.Value.Clear();
            }
            _signals.Clear();
        }
    }
}
