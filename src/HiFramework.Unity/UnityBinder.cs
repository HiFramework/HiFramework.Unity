/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/

 namespace HiFramework.Unity
{
    public class UnityBinder : HiFramework.HiFrameworkBinder
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
