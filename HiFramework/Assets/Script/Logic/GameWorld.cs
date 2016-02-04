using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HiFramework;

public class GameWorld : MonoBehaviour
{

    private List<IView> viewList = new List<IView>();


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < viewList.Count; i++)
        {
            viewList[i].OnTick(Time.deltaTime);
        }
    }
}
