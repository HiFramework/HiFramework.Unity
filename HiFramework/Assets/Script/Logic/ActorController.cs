
using HiFramework;

public class ActorController : Controller
{
    public ActorData data;
    public ActorSync sync;
    public AI ai;
    public override void OnMessage(Message paramMessage)
    {
        base.OnMessage(paramMessage);
    }
    protected void ProcessDamage()
    {

    }
}