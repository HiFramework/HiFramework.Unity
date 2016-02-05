using UnityEngine;
using System.Collections;
using HiFramework;

public class GameWorld : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
    }
}
