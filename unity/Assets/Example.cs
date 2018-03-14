//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using HiFramework;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Framework.Init();

        IIO io = Center.Get<IOComponent>();
        var file = io.ReadFile("path");
    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }

    void Read()
    {
        IIO io = Center.Get<IOComponent>();
        io.ReadFile("path");
    }

    void Event()
    {
        IEvent iEvent = Center.Get<EventComponent>();
        iEvent.Regist("hello", x =>
        {
            Debug.Log("on event");
        });

        iEvent.Dispatch("hello", null);

    }
}
