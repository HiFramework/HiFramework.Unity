//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************

using System;
using System.Collections.Generic;
using System.Reflection;

namespace HiFramework
{
    internal class Container
    {
        private Dictionary<string, IComponet> _objects = new Dictionary<string, IComponet>();

        public T Get<T>() where T : class, IComponet
        {
            var type = typeof(T);
            var key = type.FullName;
            if (_objects.ContainsKey(key))
                return _objects[key] as T;
            return Construct(type) as T;
        }

        object Construct(Type type)
        {
            var infos = GetConstructionInfos(type);
            Assert.IsNotEqual(infos.Length, 0);//组件注册类不允许构造
            var iComponent = Activator.CreateInstance(type) as IComponet;
            iComponent.Regist();
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