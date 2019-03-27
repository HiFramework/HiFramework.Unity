/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    internal class Container
    {
        private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();
        internal T Get<T>() where T : class
        {
            var key = typeof(T);
            Component component = null;
            if (_components.ContainsKey(key))
            {
                component = _components[key];
            }
            else
            {
                component = CreateComponent<T>(key);
            }
            AssertThat.IsNotNull(component, "Component is null");
            var t = component as T;
            AssertThat.IsNotNull(t, "As T is null");
            return t;
        }

        internal bool IsComponentExist<T>()
        {
            var key = typeof(T);
            return _components.ContainsKey(key);
        }

        internal void Remove<T>()
        {
            var key = typeof(T);
            AssertThat.IsTrue(_components.ContainsKey(key), "Component is not exist");
            _components.Remove(key);
        }

        internal void Remove(Component component)
        {
            AssertThat.IsTrue(_components.ContainsValue(component), "Component is not exist");
        }

        internal void DisposeAll()
        {
            var components = this._components.Values.ToList();
            for (int i = 0; i < components.Count; i++)
            {
                AssertThat.IsNotNull(components[i], "Component is null");
                components[i].Dispose();
            }
        }

        /// <summary>
        /// Create component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private Component CreateComponent<T>(Type key)
        {
            var c = Activator.CreateInstance(typeof(T)) as Component;
            AssertThat.IsNotNull(c, "Create component faild");
            AssertThat.IsFalse(_components.ContainsKey(key), "Already have this component");
            _components[key] = c;
            c.OnCreated();
            return c;
        }
    }
}
