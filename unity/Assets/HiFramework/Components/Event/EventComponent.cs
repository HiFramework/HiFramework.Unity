/***************************************************************
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

        /// <summary>
        /// Regist two param event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Regist<T, U>(string key, Action<T, U> action)
        {
            var handler = new Action_2<T, U>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Registe three parameter event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Regist<T, U, V>(string key, Action<T, U, V> action)
        {
            var handler = new Action_3<T, U, V>(action);
            RegistHandler(key, handler);
        }

        /// <summary>
        /// Registe four parameter event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="W"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
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

        /// <summary>
        /// Fire the event
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Dispatch(string key, params object[] obj)
        {
            AssertThat.IsNotNull(container.ContainsKey(key));
            var infos = container[key];
            foreach (var variable in infos)
            {
                variable.Dispatch(obj);
            }
        }

        /// <summary>
        /// Remove key and all its actions
        /// </summary>
        /// <param name="key"></param>
        public void Unregist(string key)
        {
            AssertThat.IsTrue(container.ContainsKey(key));
            container[key].Clear();
            container.Remove(key);
        }

        /// <summary>
        /// Remove one special event with same key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public void Unregist(string key, ActionBase action)
        {
            AssertThat.IsTrue(container.ContainsKey(key));
            var actions = container[key];
            AssertThat.IsTrue(actions.Contains(action));
            actions.Remove(action);
        }

        /// <summary>
        /// This will fired on component destoryed
        /// </summary>
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
