
using HiFramework;

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