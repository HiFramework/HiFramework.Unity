/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    public static class Center
    {
        internal static readonly Binder _binder = new Binder();
        internal static readonly Container _container = new Container();
        private static ITickComponent _iTickComponent;

        public static void Init()
        {
            _binder.Init();

            _iTickComponent = Get<ITickComponent>();
        }

        public static void Tick(float time)
        {
            _iTickComponent.Tick(time);
        }

        public static T Get<T>()
        {
            return _container.Get<T>();
        }
    }
}