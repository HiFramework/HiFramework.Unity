using UnityEngine;
using System.Collections;
using HiFramework;
public class Controller1 : MonoBehaviour
{
    void Start()
    {


        Facade.Mediator.Register<Controller2>(EnumCommand.StartGame);



        Message msg = new Message("method1", "test1", CallBack);
        Facade.Mediator.Dispatch(EnumCommand.StartGame, msg);
    }

    void CallBack(Message paramMessage)
    {
        Debug.Log("call back: " + paramMessage.id);
    }
}