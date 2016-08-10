//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;
using System;

namespace HiFramework
{
    /// <summary>
    /// 控制逻辑必须继承
    /// </summary>
    public interface IMessage : IMessageDispatch, IDisposable
    {
        void OnMessage(Message paramMessage);
    }
}
