using UnityEngine;
using System.Collections;

using HiFramework;


public class GameStartCommand : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        base.OnMessage(paramMessage);

        TestStart();
    }

    void TestStart()
    {

        Object obj = Resources.Load("Cube");





        GameObject go = MonoBehaviour.Instantiate(obj) as GameObject;


        ActorTest test = new ActorTest(go);
    }
}