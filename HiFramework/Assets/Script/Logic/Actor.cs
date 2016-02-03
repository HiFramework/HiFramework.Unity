using HiFramework;
using System;
using UnityEngine;

/// <summary>
/// 负责组装和销毁
/// </summary>
public class Actor : View, IDisposable
{
    public ActorController controller { get; protected set; }
    public ActorData data { get; protected set; }
    public ActorSync sync { get; protected set; }


    private bool disposed = false;

    protected void Init()
    {
        controller = new ActorController(this);
        data = new ActorData(this);
        sync = new ActorSync(this);
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
            controller = null;
            data = null;
            sync = null;
            Destroy(this);
        }
        disposed = true;
    }
}