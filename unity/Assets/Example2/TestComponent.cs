using HiFramework;

class TestComponent : ComponentBase, ITest
{
    public override void OnCreated()
    {
    }

    public override void Dispose()
    {
    }

    public void Do()
    {
        UnityEngine.Debug.Log("do");
    }
}
