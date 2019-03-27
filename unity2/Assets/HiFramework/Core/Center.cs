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
        internal static Binder Binder = new Binder();
        internal static Container Container = new Container();
        private static ITickComponent _iTickComponent;

        public static void Init()
        {
            Binder.Init();

            _iTickComponent = Get<ITickComponent>();
        }

        public static void Tick(float time)
        {
            _iTickComponent.Tick(time);
        }

        public static bool IsComponentExist<T>()
        {
            return Container.IsComponentExist<T>();
        }

        public static T Get<T>() where T : class
        {
            return Container.Get<T>();
        }

        public static void Remove<T>()
        {
            Container.Remove<T>();
        }

        public static void Remove(Component component)
        {
            Container.Remove(component);
        }

        public static void DisposeAll()
        {
            Container.DisposeAll();
        }
    }
}