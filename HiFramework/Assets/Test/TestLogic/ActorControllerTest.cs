using UnityEngine;
using System.Collections;
using HiFramework;

public class ActorControllerTest : ActorController
{


    public override void OnMessage(Message paramMessage)
    {
        Debug.logger.Log(paramMessage.id);



        Message msg = new Message("from controller", "data");



        viewEventHandler(msg);
    }
}
