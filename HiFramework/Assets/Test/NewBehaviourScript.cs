using UnityEngine;
using System.Collections;
using HiFramework;



public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject go = new GameObject("Test");


        ActorTest test = new ActorTest(go);

    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
    }
}
