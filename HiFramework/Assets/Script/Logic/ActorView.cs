using UnityEngine;
using System.Collections;

public class ActorView
{
    private GameObject gameObject;

    private Actor actor;
    public ActorView(Actor paramActor)
    {
        actor = paramActor;
    }




    public void Test()
    {
        gameObject.GetComponent<AudioClip>();
    }
}