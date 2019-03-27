/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using HiFramework;

public class Example_Bind_MyBinder : Binder
{
    public override void Init()
    {
        base.Init();
        Bind<Example_Bind_ITest>().To<Example_Bind_ITestComponent>();
    }
}