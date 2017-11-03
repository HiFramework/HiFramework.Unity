//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HiFramework
{
    /// <summary>
    /// 绑定时的信息,记录有哪些需要绑定
    /// </summary>
    public class Binding : IBinding
    {
        private List<Type> _types = new List<Type>();
        private Type _dest;
        private object _obj;
        private Action<BindingInfo> _action;
        private BindingInfo.EBindType eBindType = BindingInfo.EBindType.None;

        public Binding(Action<BindingInfo> action)
        {
            _action = action;
        }

        public IBinding Bind<T>()
        {
            if (!typeof(T).IsInterface || !typeof(T).IsClass)//目前只绑定类与接口
            {
                Assert.Exception("type is not class");
            }
            _types.Add(typeof(T));
            return this;
        }
        public IBinding To<T>()
        {
            if (typeof(T).IsSubclassOf(typeof(MonoBehaviour)))
            {
                Assert.Exception("this class is sub from monobehavior, can not bind this, use MonoBase or value instead");
            }
            if (!typeof(T).IsClass)
            {
                Assert.Exception("type is not class");
            }
            if (_dest != null)
            {
                Assert.Exception("只可对应一个实例");
            }
            if (_obj != null)
            {
                Assert.Exception("已绑定对象");
            }
            _dest = typeof(T);
            eBindType = BindingInfo.EBindType.Type;
            return this;
        }

        public IBinding ToValue(object obj)
        {
            if (_dest != null || _obj != null)
            {
                Assert.Exception("只可对应一个实例");
            }
            _obj = obj;
            eBindType = BindingInfo.EBindType.Obj;
            return this;
        }

        #region 
        // 目前都是singleton
        //一个接口可以被多个对象继承,因此类型可以绑定多个对象,key来区分不同对象
        public void AsKey(object key = null)
        {
            _action(new BindingInfo(_types, eBindType, _dest, _obj, key));
        }
        #endregion
    }
}