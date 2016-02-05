using HiFramework;

public class UI : View, ITick
{
    public void AddToTickList(ITick paramTick)
    {
        Facade.GameTick.AddToTickList(paramTick);
    }

    public virtual void OnTick()
    {
    }

    public void RemoveFromTickList(ITick paramTick)
    {
        Facade.GameTick.RemoveFromTickList(paramTick);
    }
}