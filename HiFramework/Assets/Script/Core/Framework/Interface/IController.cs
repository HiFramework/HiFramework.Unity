//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface IController : ITick, ICommand, IMessage, IDisposable
    {

    }
}