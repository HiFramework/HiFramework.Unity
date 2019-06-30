namespace HiFramework.Unity
{
    class Binder:HiFramework.Binder
    {
        public override void Init()
        {
            base.Init();
            Bind<ITickComponent>().To<TickComponent>();
            Bind<IAsyncTaskComponent>().To<AsyncTaskComponent>();
            Bind<IMainThread>().To<MainThreadComponent>();
        }
    }
}
