using HiFramework;
using System;
public class Actor : View, IDisposable
{
    public ActorController Controller { get; protected set; }
    public ActorData Data { get; protected set; }
    public ActorMove Move { get; protected set; }
    public ActorSync Sync { get; protected set; }

    private bool disposed = false;

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
            Move = null;
            Sync = null;
        }
        disposed = true;
    }
}