using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HiFramework;

public class GameWorld : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Facade.tickList.Count; i++)
        {
            Facade.tickList[i].OnTick(Time.deltaTime);
        }
    }
}
