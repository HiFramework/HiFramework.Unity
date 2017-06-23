//*********************************************************************
// Description:whole game's tick manager, this is the source of other logic's tick
// Author: hiramtan@live.com
//*********************************************************************
using UnityEngine;
using System.Collections;
using HiFramework;

public class GameTick : MonoBehaviour
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
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
    }
}
