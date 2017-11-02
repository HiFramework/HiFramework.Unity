//****************************************************************************
// Description:
// 多个类型可以绑定同一实例,比如子类父类类型同时绑定子类实例
// 一个类型可以绑定多个实例,比如接口可以被多个实例继承,通过key来区分
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HiFramework
{
    public class Binder : Component
    {
        private BindContainer _bindContainer;
        private Binding _binding;
        private Binding Binding
        {
            get
            {
                if (_binding == null)
                    _binding = new Binding(_bindContainer);
                return _binding;
            }
            set { _binding = value; }
        }

        public Binder(IContainer iContainer) : base(iContainer)
        {
            _bindContainer = new BindContainer();
        }

        public override void UnRegistComponent()
        {
            throw new NotImplementedException();
        }

        #region 绑定类型
        public Binding Bind<T>()
        {
            return this.Binding.Bind<T>();
        }

        //public Binding To<T>()
        //{
        //    return Binding.To<T>();
        //}

        #endregion
    }

    interface IInject
    {
        Binding Bind(); //可以填充多个类型,绑定同一实例
        void UnBind();
        void GetBind();
        void SetBindInstance(object obj);
    }

    /// <summary>
    /// 绑定时的信息,记录有哪些需要绑定
    /// </summary>
    public class Binding
    {
        private List<Type> _types = new List<Type>();
        public List<Type> Types { get { return _types; } }
        public Type Dest { get; private set; }
        public object Obj { get; private set; }
        private BindContainer _bindContainer;
        public Binding(BindContainer bindContainer)
        {
            _bindContainer = bindContainer;
        }

        public Binding Bind<T>()
        {
            if (!typeof(T).IsClass)
            {
                Assert.Exception("type is not class");
            }
            _types.Add(typeof(T));
            return this;
        }
        public Binding To<T>()
        {
            if (typeof(T).IsSubclassOf(typeof(MonoBehaviour)))
            {
                Assert.Exception("this class is sub from monobehavior, can not bind this, use MonoBase or value instead");
            }
            if (!typeof(T).IsClass)
            {
                Assert.Exception("type is not class");
            }
            if (Dest != null)
            {
                Assert.Exception("只可对应一个实例");
            }
            if (Obj != null)
            {
                Assert.Exception("已绑定对象");
            }
            Dest = typeof(T);
            return this;
        }
        public Binding ToValue(object obj)
        {
            if (Dest != null)
            {
                Assert.Exception("只可对应一个实例");
            }
            if (Obj != null)
            {
                Assert.Exception("已绑定对象");
            }
            Obj = obj;
            return this;
        }

        public void AsInstance()
        {
            _bindContainer
        }
        //一个接口可以被多个对象继承,因此类型可以绑定多个对象,key来区分不同对象
        public void AsNew(string key = null)
        {

        }
        //用完卸载
        public void AsOnce()
        {

        }
    }

    /// <summary>
    /// 绑定后的信息:key,对象
    /// </summary>
    public class BindInfo
    {
        //key+obj
        public Dictionary<string, object> bindInfo = new Dictionary<string, object>();
    }
}
