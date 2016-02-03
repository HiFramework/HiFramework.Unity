
using System;
using HiFramework;

public class ActorData : IModel
{
    private Actor actor;


    protected float hp;
    protected float attack;


    public ActorData(Actor paramActor)
    {
        actor = paramActor;


        UnityEngine.Debug.Log(actor.GetType());
    }
    public void Clear()
    {
    }
}