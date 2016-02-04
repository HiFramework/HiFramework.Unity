using System;
using HiFramework;

public class ActorData : IModel
{
    private Actor actor;


    protected float hp;
    protected float attack;

    private bool disposed = false;


    public ActorData(Actor paramActor)
    {
        actor = paramActor;


        UnityEngine.Debug.Log(actor.GetType());
    }
    public void Clear()
    {
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ~ActorData()
    {
        Dispose(false);
    }
    protected virtual void Dispose(bool paramDisposing)
    {
        if (disposed)
            return;
        if (paramDisposing)
        {
            Clear();
        }
        disposed = true;
    }
}