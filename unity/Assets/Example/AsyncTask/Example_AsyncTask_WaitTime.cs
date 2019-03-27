using System.Collections;
using System.Collections.Generic;
using HiFramework;
using UnityEngine;

public class Example_AsyncTask_WaitTime : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Center.Init();
        new AsyncTaskWaitTime(OnLog, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }

    void OnLog()
    {
        Debug.Log("wait for 10s");
    }
}