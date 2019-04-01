﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using HiFramework;
using UnityEngine;

public class Example_MainThread : MonoBehaviour
{
    private IMainThread mainThread;
    // Use this for initialization
    void Start()
    {
        Center.Init();
        var thread = new Thread(Do);
        thread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }

    void Do()
    {
        mainThread = Center.Get<IMainThread>();
        mainThread.RunOnMainThread(Log, null);
    }

    void Log(object obj)
    {
        Debug.LogError("this is from main thread");
    }
}