//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using UnityEngine;
using System.Collections;

using System;

namespace HiFramework
{
    public interface IAgent : ITick, ICommand, IMessage, IDisposable
    {

    }
}