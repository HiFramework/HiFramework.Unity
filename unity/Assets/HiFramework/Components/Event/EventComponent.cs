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
        /// <summary>
        /// Hold the events user registed
        /// </summary>
        private readonly Dictionary<string, List<ActionBase>> _container = new Dictionary<string, List<ActionBase>>();

        /// <summary>
        /// Regist event with no param
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Regist(string key, Action action)
        {
            var handler = new Action_0(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Regist event with object array param, user should transform type by itself
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Regist(string key, Action<object[]> action)
        {
            var handler = new Action_objects(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Regist one param event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Regist<T>(string key, Action<T> action)
        {
            var handler = new Action_1<T>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// This method handle one key with multiple action
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        private void RegistHandler(string key, ActionBase handler)
        {
            if (_container.ContainsKey(key))
            {
                _container[key].Add(handler);
            }
            else
            {
                var list = new List<ActionBase>();
                list.Add(handler);
                _container.Add(key, list);
            }
        }

        public void Dispatch(string key)
        {
            Assert.IsNotNull(_container.ContainsKey(key));
            var infos = _container[key];
            foreach (var variable in infos)
            {
                variable.Dispatch();
            }
        }

        public void Dispatch(string key, params object[] obj)
        {
            Assert.IsNotNull(_container.ContainsKey(key));
            var infos = _container[key];
            foreach (var variable in infos)
            {
                variable.Dispatch(obj);
            }
        }

        public void Dispatch<T>(string key, T t)
        {
            Assert.IsNotNull(_container.ContainsKey(key));
            var infos = _container[key];
            foreach (var variable in infos)
            {
                variable.Dispatch(t);
            }
        }

        /// <summary>
        /// Remove key and all its actions
        /// </summary>
        /// <param name="key"></param>
        public void Unregist(string key)
        {
            Assert.IsTrue(_container.ContainsKey(key));
            _container[key].Clear();
            _container.Remove(key);
        }



        public EventComponent(IContainer iContainer) : base(iContainer)
        {
        }
        public override void OnInit()
        {
        }

        public override void OnClose()
        {
            foreach (var variable in _container)
            {
                variable.Value.Clear();
            }
            _container.Clear();
        }
    }
}
