using UnityEngine;
using System.Collections;
using HFramework;
using System;

public class Test2 : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        Debug.Log(paramMessage.name);
    }
}
