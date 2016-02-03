using HiFramework;

public class Actor : View
{
    public ActorController Controller { get; protected set; }
    public ActorData Data { get; protected set; }
    public ActorMove Move { get; protected set; }
    public ActorSync Sync { get; protected set; }
}