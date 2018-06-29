//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using HiFramework;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tick = Center.Get<TickComponent>();
        tick.Tick();
    }

    void Read()
    {
        var io = Center.Get<IOComponent>();
        io.ReadFile("path");
    }
}
