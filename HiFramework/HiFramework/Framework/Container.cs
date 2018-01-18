//****************************************************************************
// Description:组件管理器,不提供热更功能,只负责组件插拔管理
// Author: hiramtan@live.com
//***************************************************************************

using System;
using System.Collections.Generic;

namespace HiFramework
{
    internal class Container : IContainer
    {
        private List<IComponent> _iComponents = new List<IComponent>();
        public void Regist(IComponent obj)
        {
            Assert.IsFalse(_iComponents.Contains(obj));
            _iComponents.Add(obj);
        }

        public bool HasComPonent<T>() where T : class, IComponent
        {
            for (int i = 0; i < _iComponents.Count; i++)
            {
                if (_iComponents[i] is T)
                {
                    return true;
                }
            }
            return false;
        }

        public void UnRegist<T>() where T : class, IComponent
        {
            if (HasComPonent<T>())
            {
                var obj = Get<T>();
                var iComponent = obj as IComponent;
                _iComponents.Remove(iComponent);
            }
        }
        public T Get<T>() where T : class, IComponent
        {
            for (int i = 0; i < _iComponents.Count; i++)
            {
                if (_iComponents[i] is T)
                {
                    return _iComponents[i] as T;
                }
            }
            return Construct(typeof(T)) as T;
        }

        object Construct(Type type)
        {
            var iComponent = Activator.CreateInstance(type, this) as IComponent;
            return iComponent;
        }
    }
}