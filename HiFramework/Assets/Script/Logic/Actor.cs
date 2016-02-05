using HiFramework;
using System;
using UnityEngine;


public abstract class Actor : ITick
{
    public ActorView view { get; protected set; }
    public ActorData data { get; protected set; }
    public ActorSync sync;
    public ActorController controller;//战斗模块派发ui事件时需要实现

    private bool disposed;
    public Actor(GameObject paramGo)
    {
        AddToTickList(this);
    }

    public void AddToTickList(ITick paramTick)
    {
        Facade.GameTick.AddToTickList(paramTick);
    }

    public void RemoveFromTickList(ITick paramTick)
    {
        Facade.GameTick.RemoveFromTickList(paramTick);
    }

    public virtual void OnTick()
    {

    }
    public void Destroy()
    {
        RemoveFromTickList(this);
        Dispose();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ~Actor()
    {
        Dispose(false);
    }
    protected virtual void Dispose(bool paramDisposing)
    {
        if (disposed)
            return;
        if (paramDisposing)
        {
            view.Destory();
            view = null;
            data = null;
            sync = null;
        }
        disposed = true;
    }
}