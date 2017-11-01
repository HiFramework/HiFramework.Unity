//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;

namespace HiFramework
{
    class InjectComponent:Component,IInject
    {
        public InjectComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void UnRegistComponent()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Bind()
        {
            throw new NotImplementedException();
        }

        public void UnBind()
        {
            throw new NotImplementedException();
        }

        public void GetBind()
        {
            throw new NotImplementedException();
        }

        public void SetBindInstance(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
