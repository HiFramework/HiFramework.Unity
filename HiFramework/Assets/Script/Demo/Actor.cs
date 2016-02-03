using HiFramework;
using System;
public class Actor : View, IDisposable
{
    public ActorController Controller { get; protected set; }
    public ActorData Data { get; protected set; }
    public ActorSync Sync { get; protected set; }

    private bool disposed = false;



    protected void Init()
    {

    }

    /// <summary>
    /// 此方法替代update
    /// </summary>
    /// <param name="paramTime"></param>
    public override void OnTick(float paramTime)
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
        }
        disposed = true;
    }
}