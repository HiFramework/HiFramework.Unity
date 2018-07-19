using HiFramework;
using UnityEngine;

public class Example_Signal : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Framework.Init();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }

    void Init()
    {
        Signal s = new Signal();
        s.AddListener(() => { Debug.Log("fire"); });
        s.Fire();

        Signal<int, int> ss = new Signal<int, int>();
        ss.AddListener((x, y) => { Debug.Log("fire" + x + y); });
        ss.Fire(10, 10);


        var c = Center.Get<SignalComponent>();
        c.AddSignal("test", ss);

        var getSignal = c.GetSignal("test") as Signal<int, int>;
        getSignal.Fire(20, 20);
    }
}
