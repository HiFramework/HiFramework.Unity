using HiFramework;
using System;

using UnityEngine;
public class Actor : MonoBehaviour, IDisposable
{
    public ActorController Controller { get; protected set; }
    public ActorData Data { get; protected set; }
    public ActorSync Sync { get; protected set; }

    public ActorView View { get; protected set; }

    private bool disposed = false;



    protected void Init()
    {

    }

    public void OnDestroy()
    {
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
            Controller = null;
            Data = null;
            Sync = null;
            Destroy(View);
        }
        disposed = true;
    }
}