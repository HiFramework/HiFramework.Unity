/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 using System.Collections;
using System.Collections.Generic;
using HiFramework;
using UnityEngine;

public class Example_AsyncTask_Repeat : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Center.Init();

        var task = new AsyncTaskRepeat(OnLog, 2);
        //task.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Tick(Time.deltaTime);
    }

    void OnLog()
    {
        Debug.Log("log every 2s");
    }
}