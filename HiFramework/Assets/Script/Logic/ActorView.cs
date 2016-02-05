using UnityEngine;
using System.Collections;

public class ActorView
{
    private Actor actor;
    private GameObject gameObject;
    public ActorView(Actor paramActor, GameObject paramGo)
    {
        actor = paramActor;
        gameObject = paramGo;
    }
    public virtual void OnTick(float paramTime)
    {
    }
}