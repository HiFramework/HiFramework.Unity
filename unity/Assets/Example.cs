//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiFramework;

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

        iEvent.Dispatch("hello",null);
    }
}
