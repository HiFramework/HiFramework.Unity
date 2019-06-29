///****************************************************************************
// * Description:Common log processer
// *
// * Author: hiramtan@live.com
// ****************************************************************************/


namespace HiFramework
{
    public static class Log
    {
        private static ILogProxy _logProxy;

        public static void SetLogProxy(ILogProxy logProxy)
        {
            _logProxy = logProxy;
        }

        public static void Print(params object[] args)
        {
            if (_logProxy != null)
            {
                _logProxy.Print(args);
            }
        }

        public static void Warnning(params object[] args)
        {
            if (_logProxy != null)
            {
                _logProxy.Warnning(args);
            }
        }

        public static void Error(params object[] args)
        {
            if (_logProxy != null)
            {
                _logProxy.Error(args);
            }
        }
    }
}
