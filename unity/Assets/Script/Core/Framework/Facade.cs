//****************************************************************************
// Description:静态管理类
// 对外接口,tick管理
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public class Facade
    {
        private static IRegistAndDispatch _iRegistAndDispatch;
        public static IRegistAndDispatch RegistAndDispatch
        {
            get
            {
                if (_iRegistAndDispatch == null)
                    _iRegistAndDispatch = _agentMap = new AgentMap();
                return _iRegistAndDispatch;
            }
        }
        private static GameTick _gameTick;
        public static GameTick GameTick
        {
            get
            {
                if (_gameTick == null)
                    _gameTick = new GameTick();
                return _gameTick;
            }
        }

        private static AgentMap _agentMap;
        public static AgentMap AgentMap
        {
            get
            {
                if (_agentMap == null)
                    _iRegistAndDispatch = _agentMap = new AgentMap();
                return _agentMap;
            }
        }

        public static void Dispose()
        {
            ((AgentMap)_iRegistAndDispatch).Dispose();
            _iRegistAndDispatch = null;
            GameTick.Dispose();
            _gameTick = null;
        }
    }
}