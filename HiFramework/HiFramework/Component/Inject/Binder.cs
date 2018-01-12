/****************************************************************
 * Description: 
 * 1.只可绑定类类型(数值类型int不能绑定)
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////

 using System;

namespace HiFramework
{
    class Binder : Component, IBinder
    {
        private IBindContainer _iBindContainer;
        public Binder(IContainer iContainer) : base(iContainer)
        {
            _iBindContainer = new BindContainer();
        }

        public override void UnRegistComponent()
        {
            throw new NotImplementedException();
        }

        public void SetUp()
        {
            throw new NotImplementedException();
        }


        public IBinding Bind<T>()
        {
            IBinding binding = new Binding(_iBindContainer);
            binding.Bind<T>();
            return binding;
        }

        public void UnBind<T>()
        {
            throw new NotImplementedException();
        }

        public void UnBind(object obj)
        {
            throw new NotImplementedException();
        }

        public object GetInstance<T>()
        {
            throw new NotImplementedException();
        }
    }
}
