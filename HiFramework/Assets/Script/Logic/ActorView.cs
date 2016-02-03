using HiFramework;
using UnityEngine;

public class ActorView : MonoBehaviour, IView
{
    public void Init(Actor paramActor)
    {

    }
    public void Dispatch<T>(T paramKey, Message paramMessage)
    {
    }

    public void OnTick(float paramTime)
    {
    }

    public void Register<T>(object paramKey) where T : IController
    {
    }

    public void Remove(object paramKey)
    {
    }
}