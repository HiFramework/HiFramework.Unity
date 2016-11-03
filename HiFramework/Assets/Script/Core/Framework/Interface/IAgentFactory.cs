//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public interface IAgentFactory : ICommand, IMessageDispatch
    {
        IDictionary<object, IAgent> agentMap { get; }
        IAgent GetAgent(string paramName);
    }
}
