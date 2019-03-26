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
        /// List to hold all _components
        /// </summary>
        private List<IComponent> _components;

        /// <summary>
        /// Tick Component to tick all _components in framework
        /// </summary>
        private ITick _tickComponent;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            AssertThat.IsNotNull(_components, "Components is null");
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Dispose();
            }
            _components.Clear();
            _components = null;
        }

        /// <summary>
        /// 框架初始化
        /// </summary>
        public void Init()
        {
            AssertThat.IsNull(_components, "Components is not null, Posible you dont dispose framework and reinit it again");
            AssertThat.IsNull(_tickComponent, "Tick _components is not null, Posible you dont dispose framework and reinit it again");
            _components = new List<IComponent>();
            _tickComponent = Get<TickComponent>();
        }

        /// <summary>
        /// Tick维护
        /// </summary>
        public void Tick(float deltaTime)
        {
            AssertThat.IsNotNull(_tickComponent, "Make sure tick is not null(should init API first to init framework)");
            _tickComponent.Tick(deltaTime);
        }

        /// <summary>
        /// 组建是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsComponentExist<T>(T t) where T : class, IComponent
        {
            return GetComponentFromList<T>() != null;
        }

        /// <summary>
        /// 获取组建（自动创建）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class, IComponent
        {
            var component = GetComponentFromList<T>();
            if (component != null)
            {
                return component as T;
            }
            return CreateComponent<T>();
        }

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Remove<T>(T t) where T : class, IComponent
        {
            var component = GetComponentFromList<T>();
            Remove(component);
        }

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <param name="component"></param>
        public void Remove(IComponent component)
        {
            AssertThat.IsNotNull(component, "Component is null");
            component.Dispose();
            _components.Remove(component);
        }

        /// <summary>
        /// Get already exist component from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private IComponent GetComponentFromList<T>() where T : class, IComponent
        {
            IComponent component = null;
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is T)
                {
                    component = _components[i] as T;
                    break;
                }
            }
            return component;
        }

        /// <summary>
        /// Add component to list
        /// </summary>
        /// <param name="component"></param>
        private void AddComponentToList(IComponent component)
        {
            AssertThat.IsNotNull(component);
            AssertThat.IsFalse(_components.Contains(component));
            _components.Add(component);
        }

        /// <summary>
        /// Create component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T CreateComponent<T>() where T : class, IComponent
        {
            var c = Activator.CreateInstance(typeof(T)) as T;
            AddComponentToList(c);
            c.OnCreated();
            return c;
        }
    }
}