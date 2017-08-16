//****************************************************************************
// Description:静态管理类
// 对外接口,tick管理
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public class Facade
    {
        private static AgentRegister iRegister;
        public static AgentRegister IRegister
        {
            get
            {
                if (iRegister == null)
                    iRegister = new AgentRegister();
                return iRegister;
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
        public static void Dispose()
        {
            IRegister.Dispose();
            iRegister = null;
            GameTick.Dispose();
            gameTick = null;
        }
    }
}