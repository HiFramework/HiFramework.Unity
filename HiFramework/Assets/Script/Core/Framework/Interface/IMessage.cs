//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    /// <summary>
    /// 控制逻辑必须继承
    /// </summary>
    public interface IMessage : IMessageDispatch, IMessageReceive
    {

    }
}
