using HiFramework;
using UnityEngine;

public class Actor : ITick
{
    public ActorView view;
    public ActorData data;
    public ActorSync sync;
    public ActorController controller;

    public Actor(GameObject paramGo)
    {
        view = new ActorView(this, paramGo);
        data = new ActorData(this);
        sync = new ActorSync(this);
        controller = new ActorController(this);
        AddToTickList(this);
    }

    public void AddToTickList(ITick paramTick)
    {
        Facade.GameTick.AddToTickList(paramTick);
    }

    public void RemoveFromTickList(ITick paramTick)
    {
        Facade.GameTick.RemoveFromTickList(this);
    }

    public virtual void OnTick()
    {

    }
}