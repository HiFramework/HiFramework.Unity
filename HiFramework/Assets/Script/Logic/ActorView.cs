using UnityEngine;
using System.Collections;

public class ActorView
{
    private Actor actor;
    protected GameObject gameObject;
    public ActorView(Actor paramActor, GameObject paramGo)
    {
        actor = paramActor;
        gameObject = paramGo;
    }
    public virtual void OnTick(float paramTime)
    {
    }

    public void Destory()
    {
        MonoBehaviour.Destroy(gameObject);
    }
}