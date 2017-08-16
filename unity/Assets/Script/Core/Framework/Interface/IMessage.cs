//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************

using System.Collections.Generic;

namespace HiFramework
{
    public interface IMessage
    {
        object Key { get; }
        List<object> Msg { get; }
    }
}
