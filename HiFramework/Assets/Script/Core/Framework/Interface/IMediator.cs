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
        IDictionary<object, object> LogicMap { get; set; }
    }
}
