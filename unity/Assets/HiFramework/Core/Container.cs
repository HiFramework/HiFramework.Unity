/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Collections.Generic;

namespace HiFramework
{
    class Container : IContainer
    {
        List<IComponent> _iComponents = new List<IComponent>();
        public void Regist(IComponent iComponent)
        {
            Assert.IsFalse(_iComponents.Contains(iComponent));
            _iComponents.Add(iComponent);
        }

        public void Unregist(IComponent iComponent)
        {
            Assert.IsTrue(_iComponents.Contains(iComponent));
            iComponent.OnClose();
            _iComponents.Remove(iComponent);
        }

        public T Get<T>() where T : class, IComponent
        {
            if (IsHave<T>()) return GetFromList<T>();
            return Create<T>();
        }

        public bool IsHave<T>() where T : class, IComponent
        {
            var c = GetFromList<T>();
            return c != null;
        }

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

        private T Create<T>() where T : class, IComponent
        {
            var c = Activator.CreateInstance(typeof(T), this) as T;
            c.OnInit();
            return c;
        }
    }
}
