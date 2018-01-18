//****************************************************************************
// Description: 核心功能只包含map和tick,其他所有功能通过组件的形式提供
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public class Center : IFramework
    {
        private static IContainer _container;
        private static ITicker _ticker;
        public static T Get<T>() where T : class, IComponent
        {
            var component = _container.Get<T>();
            return component;
        }
        public static void Remove<T>() where T : class, IComponent
        {
            _container.UnRegist<T>();
        }

        public static void RegistTick<T>(T t) where T : class, ITick
        {
            _ticker.Regist(t);
        }

        public static void UnRegistTick<T>(T t) where T : class, ITick
        {
            _ticker.UnRegist(t);
        }

        public void Init()
        {
            _container = new Container();
            _ticker = Get<Ticker>();
        }

        public void Tick()
        {
            _ticker.Tick();
        }
    }
}
