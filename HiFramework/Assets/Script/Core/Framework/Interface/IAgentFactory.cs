//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public interface IAgentFactory : ICommand, IMessageDispatch,IDisposable
    {
        IDictionary<object, IAgent> agentMap { get; }
        IAgent GetAgent(string paramName);

    }
}
