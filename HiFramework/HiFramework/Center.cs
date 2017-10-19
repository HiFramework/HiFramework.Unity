namespace HiFramework
{
    public class Center : IFramework
    {
        private static Container _container;
        private static Ticker _ticker;
        public static T Get<T>() where T : class, IComponet
        {
            var component = _container.Get<T>();
            _ticker.MakeTick(component);
            return component;
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
