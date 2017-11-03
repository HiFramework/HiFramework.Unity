//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;

namespace HiFramework
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    class InjectAttribute : Attribute
    {
    }


    interface IInject
    {
        Binding Bind(); //可以填充多个类型,绑定同一实例
        void UnBind();
        void GetBind();
        void SetBindInstance(object obj);
    }
}
