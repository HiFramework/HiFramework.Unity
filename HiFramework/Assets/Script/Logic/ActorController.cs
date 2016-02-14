using HiFramework;

/// <summary>
/// actor派发ui消息需要实现actorcontroller
/// </summary>
public class ActorController : Controller
{
    private Actor actor;

    public ActorController(Actor paramActor)
    {
        actor = paramActor;
    }
    public override void OnMessage(Message paramMessage)
    {
        base.OnMessage(paramMessage);
    }
    protected void ProcessDamage()
    {

    }
}