//****************************************************************************
// Description:组件管理器,不提供热更功能,只负责组件插拔管理
// Author: hiramtan@qq.com
//***************************************************************************

using System;
using System.Collections.Generic;
using System.Reflection;

namespace HiFramework
{
    internal class Container
    {
        private Dictionary<string, IComponent> _objects = new Dictionary<string, IComponent>();

        public bool IsNotNull(string key)
        {
            return _objects.ContainsKey(key);
        }

        public T Get<T>() where T : class, IComponent
        {
            var type = typeof(T);
            var key = type.FullName;
            if (IsNotNull(key))
                return _objects[key] as T;
            return Construct(type) as T;
        }

        public void Remove(string s)
        {
            Assert.isTrue(_objects.ContainsKey(s));
            _objects.Remove(s);
        }

        object Construct(Type type)
        {
            var infos = GetConstructionInfos(type);
            Assert.IsNotEqual(infos.Length, 0);//组件注册类不允许构造
            var iComponent = Activator.CreateInstance(type) as IComponent;
            iComponent.OnRegist();
            return iComponent;
        }

        private ConstructorInfo[] GetConstructionInfos(Type type)
        {
            return type.GetConstructors();
            //实例成员,静态成员
            //return type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}