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
        Center.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }

    void OnApplicationQuit()
    {
        Center.Dispose();
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
