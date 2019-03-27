using HiFramework;
using UnityEngine;

public class Example2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Center.SetBinder(new MyBinder());
        Center.Init();
        ITest test = Center.Get<ITest>();
        test.Do();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }
}
