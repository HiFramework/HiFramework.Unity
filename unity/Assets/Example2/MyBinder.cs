using HiFramework;

public class MyBinder : Binder
{
    public override void Init()
    {
        base.Init();
        Bind<ITest>().To<TestComponent>();
    }
}