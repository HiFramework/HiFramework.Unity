/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using HiFramework;
using HiFramework.Core;
using HiFramework.Unity;
using UnityEngine;

public class Example_Event : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Center.Init();
        var eventComponent = Center.Get<IEventComponent>();
        eventComponent.Subscribe<int>("key", OnEvent);

        eventComponent.Dispatch("key", 100);
    }

    // Update is called once per frame
    void Update()
    {
        Center.Get<ITickComponent>().Tick(Time.deltaTime);
    }

    void OnEvent(int score)
    {
        Debug.Log(score);
    }
}