/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using HiFramework;
 using HiFramework.Core;
 using HiFramework.Unity;
 using UnityEngine;

public class Example_Bind : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Center.SetBinder(new Example_Bind_MyBinder());
        Center.Init();
        Example_Bind_ITest exampleBindITest = Center.Get<Example_Bind_ITest>();
        exampleBindITest.Do();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Get<ITickComponent>().Tick(Time.deltaTime);
    }
}
