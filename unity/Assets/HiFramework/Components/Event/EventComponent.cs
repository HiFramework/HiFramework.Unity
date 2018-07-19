﻿/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class EventComponent : Component, IEvent
    {
        /// <summary>
        /// Hold the events user registed
        /// </summary>
        private readonly Dictionary<string, List<ActionBase>> container = new Dictionary<string, List<ActionBase>>();

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
            var handler = new Action_Objects(action);
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
        public void Regist<T, U>(string key, Action<T, U> action)
        {
            var handler = new Action_2<T, U>(action);
            RegistHandler(key, handler);
        }

        public void Regist<T, U, V>(string key, Action<T, U, V> action)
        {
            var handler = new Action_3<T, U, V>(action);
            RegistHandler(key, handler);
        }

        public void Regist<T, U, V, W>(string key, Action<T, U, V, W> action)
        {
            var handler = new Action_4<T, U, V, W>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// This method handle one key with multiple action
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        private void RegistHandler(string key, ActionBase handler)
        {
            if (container.ContainsKey(key))
            {
                container[key].Add(handler);
            }
            else
            {
                var list = new List<ActionBase>();
                list.Add(handler);
                container.Add(key, list);
            }
        }

        public void Dispatch(string key)
        {
            HiAssert.IsNotNull(container.ContainsKey(key));
            var infos = container[key];
            foreach (var variable in infos)
            {
                variable.Dispatch();
            }
        }

        public void Dispatch(string key, params object[] obj)
        {
            HiAssert.IsNotNull(container.ContainsKey(key));
            var infos = container[key];
            foreach (var variable in infos)
            {
                variable.Dispatch(obj);
            }
        }

        public void Dispatch<T>(string key, T t)
        {
            HiAssert.IsNotNull(container.ContainsKey(key));
            var infos = container[key];
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
            HiAssert.IsTrue(container.ContainsKey(key));
            container[key].Clear();
            container.Remove(key);
        }

        public override void OnDestory()
        {
            base.OnDestory();
            foreach (var variable in container)
            {
                variable.Value.Clear();
            }
            container.Clear();
        }
    }
}