//****************************************************************************
// Description:组件管理器,不提供热更功能,只负责组件插拔管理
// Author: hiramtan@qq.com
//***************************************************************************

using System;
using System.Collections.Generic;

namespace HiFramework
{
    internal class Container : IContainer
    {
        private readonly Dictionary<string, IComponent> _components = new Dictionary<string, IComponent>();
        public void Regist(IComponent obj)
        {
            var name = obj.GetType().FullName;
            Assert.IsFalse(HasKey(name));
            _components.Add(name, obj);
        }
        public void UnRegist(string key)
        {
            Assert.IsTrue(HasKey(key));
            _components.Remove(key);
        }
        public T Get<T>() where T : class, IComponent
        {
            var type = typeof(T);
            var key = type.FullName;
            IComponent outValue;
            _components.TryGetValue(key, out outValue);
            if (outValue != null)
                return outValue as T;
            return Construct(type) as T;
        }

        public bool HasKey(string key)
        {
            return _components.ContainsKey(key);
        }
        object Construct(Type type)
        {
            var iComponent = Activator.CreateInstance(type, this) as IComponent;
            return iComponent;
        }
        //private ConstructorInfo[] GetConstructionInfos(Type type)
        //{
        //    return type.GetConstructors();
        //    //实例成员,静态成员
        //    //return type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //}
    }
}