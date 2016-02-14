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



        for (int i = 0; i < 3; i++)
        {
            GameObject go = MonoBehaviour.Instantiate(obj) as GameObject;
            ActorTest test = new ActorTest(go);
        }

    }
}