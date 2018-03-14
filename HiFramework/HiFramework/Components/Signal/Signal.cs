/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class SignalBase
    {
        public string Key { get; private set; }
        protected ISignalComponent iSignalComponent;
        internal SignalBase(string key)
        {
            Key = key;
            iSignalComponent = Center.Get<SignalComponent>();
            iSignalComponent.AddSignal(Key, this);
        }
    }

    public class Signal : SignalBase, ISignal
    {
        List<Action> _handlers = new List<Action>();
        public Signal(string key) : base(key)
        {
        }
        public void Regist(Action handler)
        {
            _handlers.Add(handler);
        }

        public void Dispatch()
        {
            foreach (var handler in _handlers)
            {
                handler();
            }
        }

        public void UnRegist()
        {
            _handlers.Clear();
            iSignalComponent.RemoveSignal(Key);
        }

        public void UnRegist(Action handler)
        {
            Assert.IsTrue(_handlers.Contains(handler));
            _handlers.Remove(handler);
        }

  
    }

    public class Signal<T> : SignalBase, ISignal<T>
    {
        List<Action<T>> _handlers = new List<Action<T>>();
        public Signal(string key) : base(key)
        {
        }
        public void Regist(Action<T> handler)
        {
            _handlers.Add(handler);
        }

        public void Dispatch(T t)
        {
            foreach (var handler in _handlers)
            {
                handler(t);
            }
        }

        public void UnRegist()
        {
            _handlers.Clear();
            iSignalComponent.RemoveSignal(Key);
        }

        public void UnRegist(Action<T> handler)
        {
            Assert.IsTrue(_handlers.Contains(handler));
            _handlers.Remove(handler);
        }
    }

    public class Signal<T, U> : SignalBase, ISignal<T, U>
    {
        List<Action<T, U>> _handlers = new List<Action<T, U>>();
        public Signal(string key) : base(key)
        {
        }
        public void Regist(Action<T, U> handler)
        {
            _handlers.Add(handler);
        }

        public void Dispatch(T t, U u)
        {
            foreach (var handler in _handlers)
            {
                handler(t, u);
            }
        }

        public void UnRegist()
        {
            _handlers.Clear();
            iSignalComponent.RemoveSignal(Key);
        }

        public void UnRegist(Action<T, U> handler)
        {
            Assert.IsTrue(_handlers.Contains(handler));
            _handlers.Remove(handler);
        }


    }

    public class Signal<T, U, V> : SignalBase, ISignal<T, U, V>
    {
        List<Action<T, U, V>> _handlers = new List<Action<T, U, V>>();
        public Signal(string key) : base(key)
        {
        }
        public void Regist(Action<T, U, V> handler)
        {
            _handlers.Add(handler);
        }

        public void Dispatch(T t, U u, V v)
        {
            foreach (var handler in _handlers)
            {
                handler(t, u, v);
            }
        }

        public void UnRegist()
        {
            _handlers.Clear();
            iSignalComponent.RemoveSignal(Key);
        }

        public void UnRegist(Action<T, U, V> handler)
        {
            Assert.IsTrue(_handlers.Contains(handler));
            _handlers.Remove(handler);
        }

        
    }

    public class Signal<T, U, V, W> : SignalBase, ISignal<T, U, V, W>
    {
        List<Action<T, U, V, W>> _handlers = new List<Action<T, U, V, W>>();

        public Signal(string key) : base(key)
        {
        }
        public void Regist(Action<T, U, V, W> handler)
        {
            _handlers.Add(handler);
        }

        public void Dispatch(T t, U u, V v, W w)
        {
            foreach (var handler in _handlers)
            {
                handler(t, u, v, w);
            }
        }

        public void UnRegist()
        {
            _handlers.Clear();
            iSignalComponent.RemoveSignal(Key);
        }

        public void UnRegist(Action<T, U, V, W> handler)
        {
            Assert.IsTrue(_handlers.Contains(handler));
            _handlers.Remove(handler);
        }

    }
}
