using UnityEngine;
using System.Collections;
using HiFramework;

public class TestUIController : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        Debug.Log(paramMessage.ID);


        Message msg = new Message("controller msg");
        viewEventHandler(msg);
    }
}