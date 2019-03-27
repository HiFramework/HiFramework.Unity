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
        private static Container _container = new Container();
        private static ITickComponent _iTickComponent;

        public static void SetBinder(Binder binder)
        {
            AssertThat.IsNotNull(binder,"Binder is null");
            Binder = binder;
        }

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
            return _container.IsComponentExist<T>();
        }

        public static T Get<T>() where T : class
        {
            return _container.Get<T>();
        }

        public static void Remove<T>()
        {
            _container.Remove<T>();
        }

        public static void Remove(ComponentBase componentBase)
        {
            _container.Remove(componentBase);
        }

        public static void DisposeAll()
        {
            _container.DisposeAll();
        }
    }
}