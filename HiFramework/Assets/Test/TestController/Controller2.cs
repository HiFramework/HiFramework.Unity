using UnityEngine;
using System.Collections;
using HiFramework;
using System;

public class Controller2 : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        switch (paramMessage.id)
        {
            case "method1":
                Test(paramMessage);
                break;
        }

    }
    void Test(Message paramMessage)
    {
        Debug.Log("start game: " + paramMessage.body);




        //执行回调
        Message msg = new Message("test2", null);
        paramMessage.EventHandler(msg);
    }
}
