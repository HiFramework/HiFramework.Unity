/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using HiFramework.Core;
using HiFramework.Unity;
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
        Center.Get<ITickComponent>().Tick(Time.deltaTime);
    }

    void OnLog()
    {
        Debug.Log("log every 2s");
    }
}