using UnityEngine;
using System.Collections;
using HiFramework;

public class TestUI2 : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        Debug.Log(paramMessage.ID);


        Message msg = new Message("controller msg");
        viewEventHandler(msg);
    }
}