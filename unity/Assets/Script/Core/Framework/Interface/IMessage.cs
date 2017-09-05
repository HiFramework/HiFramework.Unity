//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************

using System;
using System.Collections.Generic;

namespace HiFramework
{
    public interface IMessage
    {
        string Key { get; }
        List<object> Msg { get; }

        Action<Message> CallBack { get; }
    }
}
