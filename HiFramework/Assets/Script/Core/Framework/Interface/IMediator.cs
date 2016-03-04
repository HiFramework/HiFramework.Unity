//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public interface IMediator : ICommand, IMessageDispatch
    {
        IDictionary<object, object> controllerMap { get; set; }
    }
}
