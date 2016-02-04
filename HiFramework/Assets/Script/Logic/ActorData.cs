using System;
using HiFramework;

public class ActorData : Model
{
    private Actor actor;


    protected float hp;
    protected float attack;



    public ActorData(Actor paramActor)
    {
        actor = paramActor;


        UnityEngine.Debug.Log(actor.GetType());
    }

}