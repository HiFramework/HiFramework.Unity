using HiFramework;
using UnityEngine;

public class Example_Signal : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Framework.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }

    void Init()
    {
        Signal s = new Signal();
    }
}
