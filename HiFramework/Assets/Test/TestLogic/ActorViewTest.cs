using HiFramework;
using UnityEngine;

public class ActorViewTest : ActorView
{
    public ActorViewTest(Actor paramActor, GameObject paramGo) : base(paramActor, paramGo)
    {
    }

    public void Move()
    {
        gameObject.transform.position = Vector3.left;
    }
}