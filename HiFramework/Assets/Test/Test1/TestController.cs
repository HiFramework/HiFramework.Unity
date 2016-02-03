using UnityEngine;
using System.Collections;
using HiFramework;
using System;

public class TestController : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        switch (paramMessage.ID)
        {
            case "method1":
                Test(paramMessage);
                break;
        }

    }
    void Test(Message paramMessage)
    {
        Debug.Log("start game: " + paramMessage.Body);




        //执行回调
        Message msg = new Message("test2", null);
        paramMessage.EventHandler(msg);
    }
}
