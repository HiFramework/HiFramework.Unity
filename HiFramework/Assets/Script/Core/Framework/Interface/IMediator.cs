//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public interface IMediator : ICommand
    {
        IDictionary<object, object> InstantiationMap { get; }
        object GetObj(string paramName);
    }
}
