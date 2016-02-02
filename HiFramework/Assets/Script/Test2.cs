using UnityEngine;
using System.Collections;
using HiFramework;
using System;

public class Test2 : Controller
{

    public override void OnMessage(Message paramMessage)
    {

        Debug.Log("start game: " + paramMessage.Data);




        //执行回调
        Message msg = new Message("test2", null);
        paramMessage.EventHandler(msg);
    }
}
