//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************

using System.Collections;
using System.Collections.Generic;
using HiFramework;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    private static bool isExist;
    // Use this for initialization
    void Start()
    {
        if (!isExist)
        {
            DontDestroyOnLoad(gameObject);
            isExist = true;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
    }
}
