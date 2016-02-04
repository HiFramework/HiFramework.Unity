using UnityEngine;
using System.Collections;

using HiFramework;


public class ActorTest : Actor
{
    void Start()
    {
        AddToTickList(this);

        Register<ActorControllerTest>();

        ActorControllerTest.viewEventHandler = OnMessage;



        Message msg = new Message("test");
        Dispatch(msg);
    }

    protected override void OnMessage(Message paramMessage)
    {
        base.OnMessage(paramMessage);



        Debug.Log(paramMessage.id + paramMessage.body);
    }
    public override void OnTick(float paramTime)
    {
        base.OnTick(paramTime);
        Debug.logger.Log(paramTime);
    }


}