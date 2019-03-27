/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using HiFramework;

public class MyBinder : Binder
{
    public override void Init()
    {
        base.Init();
        Bind<IAsyncTaskComponent>().To<AsyncTaskComponent>();
    }
}