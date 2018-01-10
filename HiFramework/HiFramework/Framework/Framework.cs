//****************************************************************************
// Description: 游戏框架的主体维护
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public static class Framework
    {
        private static IFramework _iFramework;
        public static void Init()
        {
            Assert.IsNull(_iFramework);
            _iFramework = new Center();
            _iFramework.Init();
        }

        public static void Tick()
        {
            Assert.IsNotNull(_iFramework);
            _iFramework.Tick();
        }
    }
}