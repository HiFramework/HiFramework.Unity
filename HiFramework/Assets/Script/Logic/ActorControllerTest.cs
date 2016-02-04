using UnityEngine;
using System.Collections;

public class ActorControllerTest : ActorController
{
    public ActorControllerTest(Actor paramActor)
        : base(paramActor)
    {

    }

    public void TestController()
    {
        Debug.Log("test controller");
    }
}
