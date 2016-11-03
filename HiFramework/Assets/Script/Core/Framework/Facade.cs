//****************************************************************************
// Description:中介,tick管理
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;
namespace HiFramework
{
    public class Facade
    {
        public Manager Mgr { get; private set; }

        public Facade()
        {
            Mgr = new Manager();
        }

        private static IAgentFactory _agentFactory;
        public static IAgentFactory AgentFactory
        {
            get
            {
                if (_agentFactory == null)
                    _agentFactory = new AgentFactory();
                return _agentFactory;
            }
        }
        private static ITick gameTick;
        public static ITick GameTick
        {
            get
            {
                if (gameTick == null)
                    gameTick = new GameTick();
                return gameTick;
            }
        }
    }
}