using HiFramework;
using System;
using UnityEngine;

/// <summary>
/// 组装
/// </summary>
public class Actor : MonoBehaviour, IDisposable
{
    public ActorController controller { get; protected set; }
    public ActorData data { get; protected set; }
    public ActorSync sync { get; protected set; }
    public ActorView view { get; protected set; }

    private bool disposed = false;



    protected void Init()
    {
        controller = new ActorController(this);
        data = new ActorData(this);
        sync = new ActorSync(this);
        view = gameObject.AddComponent<ActorView>();
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
            Destroy(view);
        }
        disposed = true;
    }
}