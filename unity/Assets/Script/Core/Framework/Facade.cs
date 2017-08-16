//****************************************************************************
// Description:静态管理类
// 对外接口,tick管理
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public class Facade
    {
        private static AgentRegister register;
        public static AgentRegister Register
        {
            get
            {
                if (register == null)
                    register = new AgentRegister();
                return register;
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
            Register.Dispose();
            register = null;
            GameTick.Dispose();
            gameTick = null;
        }
    }
}