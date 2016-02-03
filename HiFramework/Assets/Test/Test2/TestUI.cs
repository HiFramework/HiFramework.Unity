using UnityEngine;
using System.Collections;


using HiFramework;

public class TestUI : View
{
    void Awake()
    {
        Register<TestUIController>(this);
        TestUIController.viewEventHandler = ControllerEvent;
    }

    // Use this for initialization
    void Start()
    {
        Message msg = new Message("ui msg");
        Facade.Mediator.Dispatch<IView>(this, msg);
    }

    void ControllerEvent(Message msg)
    {
        Debug.Log(msg.ID);
    }
}
