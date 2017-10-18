//****************************************************************************
// Description: 游戏框架的主体围护
// Author: hiramtan@qq.com
//***************************************************************************

namespace HiFramework
{
    public static class Framework
    {
        private static IFramework _iFramework;

        internal static void Set(Map map)
        {
            _iFramework = map;
        }

        public static void Init()
        {
            _iFramework.Init();
        }

        public static void Tick()
        {
            _iFramework.Tick();
        }
    }
}