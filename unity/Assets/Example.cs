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
        Framework.Init();

        Read();
    }

    // Update is called once per frame
    void Update()
    {
        Framework.Tick();
    }

    void Read()
    {
        IIO io = Center.Get<IOComponent>();
        io.ReadFile("path");
    }
}
