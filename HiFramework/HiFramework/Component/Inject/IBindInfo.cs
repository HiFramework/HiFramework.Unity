//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    interface IBindInfo
    {
        List<Type> Types { get; }
        BindingInfo.EBindType eBindType { get; }
        Type Dest { get; }
        object Obj { get; }
        object Key { get; }
    }
}
