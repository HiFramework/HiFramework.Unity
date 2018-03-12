//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiFramework;

public class Example : MonoBehaviour
{
    private IIO io;
    // Use this for initialization
    void Start()
    {
        Framework.Init();

    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }
}
