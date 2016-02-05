using UnityEngine;


using HiFramework;
using System;

public class Actor : ITick
{
    public ActorView view;
    public ActorData data;
    public ActorSync sync;
    public ActorController controller;

    public Actor()
    {
        view = new ActorView(this);
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

    public void OnTick(float paramTime)
    {

    }
}