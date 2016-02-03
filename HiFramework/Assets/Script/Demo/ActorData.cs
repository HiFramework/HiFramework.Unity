
using System;
using HiFramework;

public class ActorData : IModel
{
    private bool disposed = false;

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

        }
        disposed = true;
    }
}