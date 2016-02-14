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


    Vector3[] test = new Vector3[] { Vector3.one, Vector3.left, Vector3.right, Vector3.zero };


}