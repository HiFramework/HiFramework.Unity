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
        public Manager manager { get; private set; }

        public Facade()
        {
            manager = new Manager();
        }

        private static IAgentFactory agentFactory;
        public static IAgentFactory AgentFactory
        {
            get
            {
                if (agentFactory == null)
                    agentFactory = new AgentFactory();
                return agentFactory;
            }
        }
        private static IGameTick gameTick;
        public static IGameTick GameTick
        {
            get
            {
                if (gameTick == null)
                    gameTick = new GameTick();
                return gameTick;
            }
        }

        public static void Dispose()
        {
            AgentFactory.Dispose();
            agentFactory = null;
            GameTick.Dispose();
            gameTick = null;
        }
    }
}