/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using HiFramework;
 using HiFramework.Core;

class Example_Bind_ITestComponent : ComponentBase, Example_Bind_ITest
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
