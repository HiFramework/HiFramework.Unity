/****************************************************************************
 * Description: Manage component
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    internal class Container : IContainer
    {
        /// <summary>
        /// Component list
        /// </summary>
        private readonly List<IComponent> _iComponents = new List<IComponent>();

        /// <summary>
        /// Remove component
        /// </summary>
        /// <param name="iComponent"></param>
        public void Remove(IComponent iComponent)
        {
            HiAssert.IsTrue(_iComponents.Contains(iComponent));
            _iComponents.Remove(iComponent);
            iComponent.OnRemoved();
            iComponent = null;
        }

        /// <summary>
        /// Get component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class, IComponent
        {
            if (IsExist<T>())
            {
                return GetFromList<T>();
            }
            return Create<T>();
        }

        /// <summary>
        /// If this component is exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool IsExist<T>() where T : class, IComponent
        {
            var c = GetFromList<T>();
            return c != null;
        }

        /// <summary>
        /// Get componet from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T GetFromList<T>() where T : class, IComponent
        {
            IComponent iComponent = null;
            for (int i = 0; i < _iComponents.Count; i++)
            {
                if (_iComponents[i] is T)
                {
                    iComponent = _iComponents[i];
                    break;
                }
            }
            return iComponent as T;
        }

        /// <summary>
        /// Add component to container
        /// </summary>
        /// <param name="component"></param>
        private void AddToList(IComponent component)
        {
            HiAssert.IsNotNull(component);
            HiAssert.IsFalse(_iComponents.Contains(component));
            _iComponents.Add(component);
        }

        /// <summary>
        /// Create Component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T Create<T>() where T : class, IComponent
        {
            var c = Activator.CreateInstance(typeof(T)) as T;
            AddToList(c);
            c.OnCreated();
            return c;
        }
    }
}