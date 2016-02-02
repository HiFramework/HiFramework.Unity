using UnityEngine;
using System.Collections;
using HiFramework;
using System;

public class Test2 : Controller
{

    public override void OnMessage(Message paramMessage)
    {
        Debug.Log(paramMessage.name);
    }

}
