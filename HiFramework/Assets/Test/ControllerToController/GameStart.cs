using UnityEngine;
using System.Collections;
using HiFramework;
public class GameStart : MonoBehaviour
{
    void Start()
    {
        new GameObject(Common.gameworldName).AddComponent<Gameworld>();



        Facade.Mediator.Register<TestController>(EnumCommand.StartGame);



        Message msg = new Message("method1", "test1", CallBack);
        Facade.Mediator.Dispatch(EnumCommand.StartGame, msg);
    }

    void CallBack(Message paramMessage)
    {
        Debug.Log("call back: " + paramMessage.body);
    }
}