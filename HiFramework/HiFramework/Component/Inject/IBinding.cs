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
    public interface IBinding
    {
        IBinding Bind<T>();
        IBinding To<T>();
        IBinding ToValue(object obj);
    }
}
