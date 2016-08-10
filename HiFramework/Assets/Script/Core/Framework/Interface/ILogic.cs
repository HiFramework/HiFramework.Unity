//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using UnityEngine;
using System.Collections;

using System;

namespace HiFramework
{
    public interface ILogic : ITick, ICommand, IMessage
    {

    }
}