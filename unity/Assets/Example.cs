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
    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }

    void OnApplicationQuit()
    {
        Framework.Destory();
    }

    void Read()
    {
        var io = Center.Get<IOComponent>();
        io.ReadFile("path");
    }

    void Event()
    {
        var events = Center.Get<EventComponent>();
        events.Subscribe("key", () => { });
    }
}
