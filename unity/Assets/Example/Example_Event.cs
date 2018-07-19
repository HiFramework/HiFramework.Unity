using HiFramework;
using UnityEngine;

public class Example_Event : MonoBehaviour
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
        var events = Center.Get<EventComponent>();
        events.Subscribe("key1", () => { Debug.Log("key1 event"); });
        events.Subscribe("key2", (int x) => { Debug.Log("key2 event" + x); });
        events.Subscribe("key3", (int x, int y) => { Debug.Log("key3 event" + x + y); });
        events.Subscribe<int, int>("key4", OnTest);

        events.Dispatch("key1");
        events.Dispatch("key2", 10);
        events.Dispatch("key3", 10, 10);
        events.Dispatch("key4", 20, 20);
    }

    void OnTest(int x, int y)
    {
        Debug.Log("key4 event" + x + y);
    }
}