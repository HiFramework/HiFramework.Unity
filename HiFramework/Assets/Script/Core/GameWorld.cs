//*********************************************************************
// Description:
// Author: hiramtan@live.com
//*********************************************************************
using UnityEngine;
using System.Collections;
using HiFramework;

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
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
    }
}
