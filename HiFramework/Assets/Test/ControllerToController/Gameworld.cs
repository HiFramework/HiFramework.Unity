using UnityEngine;
using System.Collections;
using HiFramework;

public class Gameworld : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        //Facade.Mediator.OnTick(Time.deltaTime);
    }
}
