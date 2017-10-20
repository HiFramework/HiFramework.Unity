namespace HiFramework
{
    public class Center : IFramework
    {
        private static Container _container;
        private static Ticker _ticker;
        public static T Get<T>() where T : class, IComponent
        {
            var component = _container.Get<T>();
            _ticker.RegistTick(component);
            return component;
        }

        public static void Remove<T>() where T : class, IComponent
        {
            var key = typeof(T).FullName;
            var isNotNull = _container.IsNotNull(key);
            Assert.isTrue(isNotNull);
            var component = Get<T>();
            _ticker.UnRegistTick(component);
            _container.Remove(key);
        }

        public void Init()
        {
            _container = new Container();
            _ticker = new Ticker();
        }

        public void Tick()
        {
            _ticker.Tick();
        }
    }
}
