/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiFramework
{
    internal class Container
    {
        private readonly Dictionary<Type, ComponentBase> _components = new Dictionary<Type, ComponentBase>();
        internal T Get<T>() where T : class
        {
            var key = typeof(T);
            ComponentBase componentBase = null;
            if (_components.ContainsKey(key))
            {
                componentBase = _components[key];
            }
            else
            {
                componentBase = CreateComponent<T>(key);
            }
            AssertThat.IsNotNull(componentBase, "ComponentBase is null");
            var t = componentBase as T;
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
            AssertThat.IsTrue(_components.ContainsKey(key), "ComponentBase is not exist");
            _components.Remove(key);
        }

        internal void Remove(ComponentBase componentBase)
        {
            AssertThat.IsTrue(_components.ContainsValue(componentBase), "ComponentBase is not exist");
        }

        internal void DisposeAll()
        {
            var components = this._components.Values.ToList();
            for (int i = 0; i < components.Count; i++)
            {
                AssertThat.IsNotNull(components[i], "ComponentBase is null");
                components[i].Dispose();
            }
        }

        /// <summary>
        /// Create componentBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private ComponentBase CreateComponent<T>(Type key)
        {
            var componentType = Center.Binder.BindInfos[key];
            AssertThat.IsNotNull(componentType, "Have not bind this type");
            var c = Activator.CreateInstance(componentType) as ComponentBase;
            AssertThat.IsNotNull(c, "Create component faild");
            AssertThat.IsFalse(_components.ContainsKey(key), "Already have this component");
            _components[key] = c;
            c.OnCreated();
            return c;
        }
    }
}
