using HiFramework;
using HiFramework.Core;
using HiFramework.Unity;
using UnityEngine;

public class Example_Inject : MonoBehaviour
{
    public int Score = 100;

    // Use this for initialization
    void Start()
    {
        Center.Init();
        var inject = Center.Get<IInjectComponent>();
        inject.Bind<Example_Inject>().To(this);

        var newClass = new Example_Inject_NewClass();
        inject.Inject(newClass);
        newClass.Log();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Get<ITickComponent>().Tick(Time.deltaTime);
    }
}