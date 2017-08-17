//****************************************************************************
// Description:静态管理类
// 对外接口,tick管理
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public class Facade
    {
        private static IRegistAndDispatch iRegistAndDispatch;
        public static IRegistAndDispatch IRegistAndDispatch
        {
            get
            {
                if (iRegistAndDispatch == null)
                    iRegistAndDispatch = agentMap = new AgentMap();
                return iRegistAndDispatch;
            }
        }
        private static GameTick gameTick;
        public static GameTick GameTick
        {
            get
            {
                if (gameTick == null)
                    gameTick = new GameTick();
                return gameTick;
            }
        }

        private static AgentMap agentMap;
        public static AgentMap AgentMap
        {
            get
            {
                if (agentMap == null)
                    iRegistAndDispatch = agentMap = new AgentMap();
                return agentMap;
            }
        }

        public static void Dispose()
        {
            ((AgentMap)iRegistAndDispatch).Dispose();
            iRegistAndDispatch = null;
            GameTick.Dispose();
            gameTick = null;
        }
    }
}