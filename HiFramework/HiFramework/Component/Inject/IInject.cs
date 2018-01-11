//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    interface IInject
    {
        Binding Bind(); //可以填充多个类型,绑定同一实例
        void UnBind();
        void GetBind();
        void SetBindInstance(object obj);
    }
}
