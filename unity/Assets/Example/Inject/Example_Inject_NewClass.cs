using System.Collections;
using System.Collections.Generic;
using HiFramework;
using UnityEngine;

public class Example_Inject_NewClass
{
    [Inject]
    private Example_Inject exampleInject;


    public void Log()
    {
        Debug.Log(exampleInject.Score);
    }

}