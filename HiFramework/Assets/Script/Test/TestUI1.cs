using UnityEngine;
using System.Collections;


using HiFramework;

public class TestUI1 : View
{
    void Awake()
    {
        Register<TestUI2>(this);
        TestUI2.viewEventHandler = ControllerEvent;
    }

    // Use this for initialization
    void Start()
    {
        Message msg = new Message("ui msg");
        Facade.Mediator.Dispatch<IView>(this, msg);
    }

    void ControllerEvent(Message msg)
    {
        Debug.Log(msg.Body);
    }
}
