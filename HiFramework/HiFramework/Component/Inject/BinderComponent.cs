/****************************************************************
 * Description: 
 * 1.只可绑定类类型(数值类型int不能绑定)
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////

 using System;

namespace HiFramework
{
  public  class BinderComponent : Component, IBinder
    {
        private IBindContainer _iBindContainer;
        public BinderComponent(IContainer iContainer) : base(iContainer)
        {
            _iBindContainer = new BindContainer();
        }

        public override void UnRegistComponent()
        {
            throw new NotImplementedException();
        }

        public void SetUp()
        {
            _iBindContainer.GenerateBindInfo();
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

        public void Inject(object obj)
        {
            _iBindContainer.Inject(obj);
        }
    }
}
